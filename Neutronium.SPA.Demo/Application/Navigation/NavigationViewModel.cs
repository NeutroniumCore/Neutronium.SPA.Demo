using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Neutronium.Core.Navigation;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.SPA.Demo.Application.Ioc;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    public class NavigationViewModel : Vm.Tools.ViewModel, INavigator 
    {
        public IResultCommand BeforeResolveCommand { get; }
        public ISimpleCommand<string> AfterResolveCommand { get; }

        private string _Route;
        public string Route 
        {
            get { return _Route; }
            set { Set(ref _Route, value); }
        }

        public event EventHandler<NavigationEvent> OnNavigate;

        private readonly IServiceLocator _ServiceLocator;
        private readonly IRouterSolver _RouterSolver;
        private readonly Queue<RouteContext> _currentNavigations = new Queue<RouteContext>();

        private object _ViewModel;

        public NavigationViewModel(object viewModel, Func<INavigator, IServiceLocator> serviceLocatorBuilder, IRouterSolver routerSolver, out IServiceLocator serviceLocator)
        {
            _ViewModel = viewModel;            
            serviceLocator = serviceLocatorBuilder(this);
            _ServiceLocator = serviceLocator;
            _RouterSolver = routerSolver;
            AfterResolveCommand = new RelaySimpleCommand<string>(AfterResolve);
            BeforeResolveCommand = RelayResultCommand.Create<string, bool>(BeforeResolve);
        }

        public struct NavigationViewModelAterFacts 
        {
            public NavigationViewModelAterFacts(IServiceLocator serviceLocator, NavigationViewModel navigationViewModel) 
            {
                ServiceLocator = serviceLocator;
                ViewModel = navigationViewModel;
            }
            public IServiceLocator ServiceLocator { get; }
            public NavigationViewModel ViewModel { get; }
        }

        public static NavigationViewModelAterFacts Create(object viewModel, Func<INavigator, IServiceLocator> serviceLocatorBuilder, IRouterSolver routerSolver) 
        {            
            serviceLocatorBuilder = serviceLocatorBuilder ?? CreateWithNavigator;
            IServiceLocator serviceLocator = null;
            var navigationViewModel = new NavigationViewModel(viewModel, serviceLocatorBuilder, routerSolver, out serviceLocator);
            return new NavigationViewModelAterFacts(serviceLocator, navigationViewModel);
        }

        private static IServiceLocator CreateWithNavigator(INavigator navigator) 
        {
            return new TrivialServiceLocator().Add(navigator);
        }

        private bool BeforeResolve(string routeName)
        {
            var context = GetRouteContext(routeName);
            if (context == null)
                return false;

            Navigate(context.ViewModel);
            return true;
        }

        private void Navigate(object viewModel) 
        {
            OnNavigate?.Invoke(this, new NavigationEvent(viewModel, _ViewModel));
            _ViewModel = viewModel;
        }

        private RouteContext GetRouteContext(string routeName)
        {
            if (_currentNavigations.Count == 0)
                return CreateRouteContext(routeName);

            var context = _currentNavigations.Peek();
            if (context.Route != routeName) 
            {
                Console.WriteLine($"Navigation inconsistency: from browser {routeName}, from context: {context.Route}");
                return null;
            }       

            return context;
        }

        private RouteContext CreateRouteContext(string routeName)
        {
            var type = _RouterSolver.SolveType(routeName);
            var vm = _ServiceLocator.GetInstance(type);
            return CreateRouteContext(vm, routeName);
        }

        private RouteContext CreateRouteContext(object viewModel, string routeName) 
        {
            var routeContext = new RouteContext(viewModel, routeName);
            _currentNavigations.Enqueue(routeContext);
            return routeContext;
        }

        private void AfterResolve(string routeName)
        {
            var context = _currentNavigations.Dequeue();
            if (context.Route != routeName) 
            {
                Console.WriteLine($"Navigation inconsistency: from browser {routeName}, from context: {context.Route}. Maybe rerouted?");
            }
            Route = routeName;
            context.Complete();
        }

        public Task Navigate(object viewModel, string routerName = null)
        {
            var route = routerName ?? _RouterSolver.SolveRoute(viewModel);
            var routeContext = CreateRouteContext(viewModel, route);
            Route = route;
            return routeContext.Task;
        }

        public async Task Navigate<T>(NavigationContext<T> context = null)
        {
            var resolutionKey = context?.ResolutionKey;
            var vm = (resolutionKey == null) ? _ServiceLocator.GetInstance<T>() : _ServiceLocator.GetInstance<T>(resolutionKey);
            context?.BeforeNavigate(vm);
            await Navigate(vm, context?.RouteName);
        }

        public async Task Navigate(Type type, NavigationContext context = null)
        {
            var resolutionKey = context?.ResolutionKey;
            var vm = (resolutionKey == null) ? _ServiceLocator.GetInstance(type) : _ServiceLocator.GetInstance(type, resolutionKey);
            await Navigate(vm, context?.RouteName);
        }
    }
}
