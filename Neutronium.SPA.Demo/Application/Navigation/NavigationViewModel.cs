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
    public class NavigationViewModel : INavigator
    {
        public IResultCommand BeforeResolveCommand { get; }
        public ISimpleCommand<string> AfterResolveCommand { get; }
        public string Route { get; set; }

        public event EventHandler<NavigationEvent> OnNavigate;

        private readonly IServiceLocator _ServiceLocator;
        private readonly IRouterSolver _RouterSolver;
        private readonly Queue<RouteContext> _currentNavigations = new Queue<RouteContext>();

        public NavigationViewModel(IServiceLocator serviceLocator, IRouterSolver routerSolver)
        {
            _ServiceLocator = serviceLocator ??  new TrivialServiceLocator().Add(this);
            _RouterSolver = routerSolver;
            AfterResolveCommand = new RelaySimpleCommand<string>(OnEndNavigate);
            BeforeResolveCommand = RelayResultCommand.Create<string, bool>(Navigate);
        }

        private bool Navigate(string routeName)
        {
            var context = GetRouteContext(routeName);
            Console.WriteLine($"begin navigation {routeName}");
            return true;
        }

        private RouteContext GetRouteContext(string routeName)
        {
            if (_currentNavigations.Count == 0)
                return CreateRouteContext(routeName);

            var context = _currentNavigations.Dequeue();
            if (context.Route != routeName)
                throw new InvalidOperationException($"Navigation inconstency: from browser {routeName}, from context: {context.Route}");

            return context;
        }

        private RouteContext CreateRouteContext(string routeName)
        {
            var type = _RouterSolver.SolveType(routeName);
            var vm = _ServiceLocator.GetInstance(type);
            return new RouteContext(vm, routeName);
        }

        private void OnEndNavigate(string routeName)
        {
            var context = _currentNavigations.Peek();
            if (context.Route != routeName)
                throw new InvalidOperationException($"Navigation inconstency: from browser {routeName}, from context: {context.Route}");

            _currentNavigations.Dequeue();
            context.Complete();
        }

        public Task Navigate(object viewModel, string routerName = null)
        {
            var route = routerName ?? _RouterSolver.SolveRoute(viewModel);
            var routeContext = new RouteContext(viewModel, route);
            _currentNavigations.Enqueue(routeContext);
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
