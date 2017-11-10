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

        private Vm.Tools.ViewModel _CurrentViewModel;
        public Vm.Tools.ViewModel CurrentViewModel 
        {
            get { return _CurrentViewModel; }
            set { Set(ref _CurrentViewModel, value); }
        }

        public ApplicationViewModel(WindowViewModel window, IServiceLocator serviceLocator, IRouterSolver routerSolver)
        {
            Window = window;
            Router = new NavigationViewModel(serviceLocator, routerSolver);
        }
    }
}
