using System;
using System.Threading.Tasks;
using Neutronium.SPA.Demo.Application.Ioc;
using Neutronium.SPA.Demo.Application.Navigation;
using Neutronium.WPF.ViewModel;
using Vm.Tools.Application;

namespace Neutronium.SPA.Demo.ViewModel 
{
    public class ApplicationViewModel : Vm.Tools.ViewModel, IConfirmationDisplayer 
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

        private MainModalViewModel _Modal;
        public MainModalViewModel Modal 
        {
            get { return _Modal; }
            private set { Set(ref _Modal, value); }
        }

        private readonly IApplication _Application;

        public static ApplicationViewModel CreateApplicationViewModel<T>(IWindowViewModel window, IRouterSolver routerSolver, IDependencyInjectionConfiguration serviceLocatorBuilder =null) 
        {
            serviceLocatorBuilder = serviceLocatorBuilder ?? new TrivialDependencyInjectionConfiguration();

            var serviceLocator = serviceLocatorBuilder.GetServiceLocator();
            var navigation = NavigationViewModel.Create(serviceLocator, routerSolver);
            return new ApplicationViewModel(window, navigation, serviceLocatorBuilder, typeof(T));
        }

        private ApplicationViewModel(IWindowViewModel window, NavigationViewModel router, IDependencyInjectionConfiguration serviceLocatorBuilder, Type initialType)
        {
            Window = window;
            Router = router;

            RegisterApplicationDependency(serviceLocatorBuilder);

            var serviceLocator = serviceLocatorBuilder.GetServiceLocator();
            
            _Application = serviceLocator.GetInstance<IApplication>();

            var currentViewModel = serviceLocator.GetInstance(initialType);
            CurrentViewModel = currentViewModel;

            _Application.MainWindowClosing += _Application_MainWindowClosing;

            Router.SetInitialVm(currentViewModel);
            Router.OnNavigated += Router_OnNavigated;
        }

        private async void _Application_MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e) 
        {
            var message = new MessageInformation("Warning", "Do you want to close application?");
            e.Cancel = await ShowMessage(message);
        }

        private void RegisterApplicationDependency(IDependencyInjectionConfiguration serviceLocatorBuilder) 
        {
            serviceLocatorBuilder.Register<IConfirmationDisplayer>(this);
            serviceLocatorBuilder.Register(Window);
            serviceLocatorBuilder.Register<INavigator>(Router);
        }

        public async Task<bool> ShowMessage(MessageInformation messageInformation) 
        {
            var modal = new MainModalViewModel(messageInformation);
            Modal = modal;
            if (modal != null)
                return false;
            return await modal.CompletionTask;
        }

        private void Router_OnNavigated(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = e.NewRoute.ViewModel;
        }
    }
}
