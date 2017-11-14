using System.ComponentModel;
using System.Threading.Tasks;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.SPA.Demo.WindowServices;

namespace Neutronium.SPA.Demo.ViewModel.Modal 
{
    public class MainModalViewModel : MessageModalViewModel
    {
        public string CancelMessage { get; }

        [Bindable(false)]
        public bool? Result { get; set; }

        [Bindable(false)]
        public Task<bool> CompletionTask => _TaskCompletionSource.Task;

        public ISimpleCommand CancelCommand { get; }

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
            if (_TaskCompletionSource.TrySetResult(value))
                Result = value;
        }
    }
}