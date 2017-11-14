using System.Threading.Tasks;
using Neutronium.SPA.Demo.Application.Navigation;
using Neutronium.SPA.Demo.ViewModel.Modal;
using Neutronium.SPA.Demo.WindowServices;
using Neutronium.WPF.ViewModel;
using Vm.Tools.Application;

namespace Neutronium.SPA.Demo.ViewModel 
{
    public class ApplicationViewModel : Vm.Tools.ViewModel, IMessageBox 
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

        private MessageModalViewModel _Modal;
        public MessageModalViewModel Modal 
        {
            get { return _Modal; }
            private set { Set(ref _Modal, value); }
        }

        private readonly IApplication _Application;

        public ApplicationViewModel(IWindowViewModel window, IApplication application, NavigationViewModel router)
        {
            Window = window;
            Router = router;
            _Application = application;

            Router.OnNavigated += Router_OnNavigated;
            _Application.MainWindowClosing += _Application_MainWindowClosing;
        }

        private async void _Application_MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var message = new ConfirmationMessage("Closing", "Sure?");
            e.Cancel = !await ShowMessage(message);
        }

        public Task<bool> ShowMessage(ConfirmationMessage confirmationMessage) 
        {
            var modal = new MainModalViewModel(confirmationMessage);
            Modal = modal;
            return modal.CompletionTask;
        }

        public void ShowInformation(MessageInformation messageInformation)
        {
            var modal = new MessageModalViewModel(messageInformation);
            Modal = modal;
        }

        private void Router_OnNavigated(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = e.NewRoute.ViewModel;
        }

        public ApplicationViewModel StartRoute<T>()
        {
            Router.StartRoute<T>();
            return this;
        }
    }
}
