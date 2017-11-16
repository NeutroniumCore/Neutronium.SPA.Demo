using System.ComponentModel;
using System.Threading.Tasks;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.SPA.Demo.Application.WindowServices;

namespace Neutronium.SPA.Demo.ViewModel.Modal 
{
    public class MainModalViewModel : MessageModalViewModel
    {
        public string CancelMessage { get; }

        public ISimpleCommand CancelCommand { get; }

        [Bindable(false)]
        public Task<bool> CompletionTask => _TaskCompletionSource.Task;

        private readonly TaskCompletionSource<bool> _TaskCompletionSource = new TaskCompletionSource<bool>();

        public MainModalViewModel(ConfirmationMessage confirmationMessage) :base(confirmationMessage)
        {
            CancelMessage = confirmationMessage.CancelMessage;
            CancelCommand = new RelaySimpleCommand(Cancel);
        }

        protected override void Ok() => SetResult(true);

        private void Cancel() => SetResult(false);

        private void SetResult(bool value)
        {
            _TaskCompletionSource.TrySetResult(value);
        }
    }
}