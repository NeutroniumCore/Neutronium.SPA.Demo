using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.SPA.Demo.Application.Navigation;
using Neutronium.SPA.Demo.Application.WindowServices;
using Vm.Tools.Application;

namespace Neutronium.SPA.Demo.ViewModel.Pages 
{
    public class MainViewModel 
    {
        public ISimpleCommand GoToAbout { get; }
        public ISimpleCommand Restart { get; }

        private readonly INavigator _Navigator;
        private readonly IApplication _Application;
        private readonly IMessageBox _MessageBox;

        public MainViewModel(INavigator navigator, IApplication application, IMessageBox messageBox)
        {
            _Navigator = navigator;
            _Application = application;
            _MessageBox = messageBox;
            GoToAbout = new RelaySimpleCommand(DoGoToAbout);
            Restart = new RelaySimpleCommand(DoRestart);
        }

        private void DoGoToAbout() 
        {
            _Navigator.Navigate<AboutViewModel>();
        }

        private async void DoRestart()
        {
            var message = new ConfirmationMessage(Resource.ConfirmationNeeded, Resource.DoYouWantToRestartApplication);
            var res = await _MessageBox.ShowMessage(message);

            if (res)
                _Application.Restart();
        }
    }
}
