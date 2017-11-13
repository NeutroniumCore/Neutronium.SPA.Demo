using System;
using Microsoft.Practices.ServiceLocation;
using Neutronium.SPA.Demo.Application.Navigation;
using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo.ViewModel
{
    public class ApplicationViewModel : Vm.Tools.ViewModel
    {
        public ApplicationInformation ApplicationInformation { get; } = new ApplicationInformation();
        public IWindowViewModel Window { get; }
        public NavigationViewModel Router { get; }

        private object _CurrentViewModel;
        public object CurrentViewModel 
        {
            get { return _CurrentViewModel; }
            private set { Set(ref _CurrentViewModel, value); }
        }

        public static ApplicationViewModel CreateApplicationViewModel<T>(WindowViewModel window, IRouterSolver routerSolver, Func<INavigator, IServiceLocator> serviceLocatorBuilder=null) 
        {
            var routerArtefacts = NavigationViewModel.Create(serviceLocatorBuilder, serviceLocatorBuilder, routerSolver);
            var viewModel = routerArtefacts.ServiceLocator.GetInstance(typeof(T));
            return new ApplicationViewModel(viewModel, window, routerArtefacts.ViewModel);
        }

        private ApplicationViewModel(object initialViewModel, WindowViewModel window, NavigationViewModel router)
        {
            CurrentViewModel = initialViewModel;
            Window = window;
            Router = router;
            Router.OnNavigated += Router_OnNavigated;
        }

        private void Router_OnNavigated(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = e.NewRoute.ViewModel;
        }
    }
}
