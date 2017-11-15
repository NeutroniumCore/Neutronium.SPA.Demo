using System;
using Microsoft.Practices.ServiceLocation;
using Neutronium.SPA.Demo.Application.LifeCycleHook;
using Neutronium.SPA.Demo.Application.Navigation;
using Neutronium.SPA.Demo.Application.WindowServices;
using Neutronium.SPA.Demo.ViewModel;
using Neutronium.SPA.Demo.ViewModel.Pages;
using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private LifeCycleEventsRegistror _LifeCycleEventsRegistror;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = BuildApplicationViewModel();
        }

        private ApplicationViewModel BuildApplicationViewModel()
        {
            var window = new WindowViewModel(this);
            var routeSolver = RoutingConfiguration.Register();
            var serviceLocatorBuilder = new DependencyInjectionConfiguration();
            var serviceLocator = serviceLocatorBuilder.GetServiceLocator();

            var navigation = NavigationViewModel.Create(serviceLocator, routeSolver);

            serviceLocatorBuilder.Register<IWindowViewModel>(window);
            serviceLocatorBuilder.Register<INavigator>(navigation);
            serviceLocatorBuilder.Register(navigation);

            var application = serviceLocator.GetInstance<ApplicationViewModel>();
            serviceLocatorBuilder.Register<IMessageBox>(application);

            _LifeCycleEventsRegistror = RegisterLifeCycleEvents(serviceLocator);

            return application.StartRoute<MainViewModel>();
        }

        private LifeCycleEventsRegistror RegisterLifeCycleEvents(IServiceLocator serviceLocator)
        {
            var registor = serviceLocator.GetInstance<LifeCycleEventsRegistror>();
            return registor.Register();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.HtmlView.Dispose();
        }
    }
}
