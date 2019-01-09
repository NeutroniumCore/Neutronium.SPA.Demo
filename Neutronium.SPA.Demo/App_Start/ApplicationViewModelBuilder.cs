using System.Windows;
using CommonServiceLocator;
using Neutronium.BuildingBlocks.Application.LifeCycleHook;
using Neutronium.BuildingBlocks.Application.Navigation;
using Neutronium.BuildingBlocks.Application.ViewModels;
using Neutronium.BuildingBlocks.Application.WindowServices;
using Neutronium.MVVMComponents;
using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo
{
    public class ApplicationViewModelBuilder
    {
        public ApplicationViewModel<ApplicationInformation> ApplicationViewModel { get; }
        private readonly LifeCycleEventsRegister _LifeCycleEventsRegister;

        public ApplicationViewModelBuilder(Window wpfWindow)
        {
            var window = new WindowViewModel(wpfWindow);
            var routeSolver = RoutingConfiguration.Register();
            var serviceLocatorBuilder = new DependencyInjectionConfiguration();
            var serviceLocatorLazy = serviceLocatorBuilder.GetServiceLocator();

            var navigation = new NavigationViewModel(serviceLocatorLazy, routeSolver);

            serviceLocatorBuilder.Register<IWindowViewModel>(window);
            serviceLocatorBuilder.Register<INavigator>(navigation);
            serviceLocatorBuilder.Register(navigation);

            ApplicationViewModel = new ApplicationViewModel<ApplicationInformation>(window, navigation, new ApplicationInformation("Neutronium Demo", "David Desmaisons"));
            serviceLocatorBuilder.Register<IMessageBox>(ApplicationViewModel);
            serviceLocatorBuilder.Register<INotificationSender>(ApplicationViewModel);

            var serviceLocator = serviceLocatorLazy.Value;
            _LifeCycleEventsRegister = RegisterLifeCycleEvents(serviceLocator);
        }

        private static LifeCycleEventsRegister RegisterLifeCycleEvents(IServiceLocator serviceLocator)
        {
            var register = serviceLocator.GetInstance<LifeCycleEventsRegister>();
            return register.Register();
        }
    }
}
