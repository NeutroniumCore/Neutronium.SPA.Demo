using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.SPA.Demo.Application.Navigation;
using Vm.Tools.Application;

namespace Neutronium.SPA.Demo.ViewModel.Pages 
{
    public class MainViewModel 
    {
        public string Nome => "Main";

        public ISimpleCommand GoToAbout { get; }
        public ISimpleCommand Restart { get; }

        private readonly INavigator _Navigator;
        private readonly IApplication _Application;

        public MainViewModel(INavigator navigator, IApplication application)
        {
            _Navigator = navigator;
            _Application = application;
            GoToAbout = new RelaySimpleCommand(DoGoToAbout);
            Restart = new RelaySimpleCommand(DoRestart);
        }

        private void DoGoToAbout() 
        {
            _Navigator.Navigate<AboutViewModel>();
        }

        private void DoRestart()
        {
            _Application.Restart();
        }
    }
}
