using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.SPA.Demo.Application.Navigation;

namespace Neutronium.SPA.Demo.ViewModel.Menu 
{
    public class MainViewModel 
    {
        public string Nome => "Main";

        public ISimpleCommand GoToAbout { get; }

        private readonly INavigator _Navigator;

        public MainViewModel(INavigator navigator)
        {
            _Navigator = navigator;
            GoToAbout = new RelaySimpleCommand(DoGoToAbout);
        }

        private void DoGoToAbout() 
        {
            _Navigator.Navigate<AboutViewModel>();
        }
    }
}
