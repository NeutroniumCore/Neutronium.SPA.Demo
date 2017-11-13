using System.ComponentModel;
using System.Threading.Tasks;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;

namespace Neutronium.SPA.Demo.ViewModel 
{
    public class MainModalViewModel 
    {
        public string Title { get; }
        public string Message { get; }
        public string OkMessage { get; }
        public string CancelMessage { get; }

        [Bindable(false)]
        public bool? Result { get; set; }

        public Task<bool> CompletionTask => _TaskCompletionSource.Task;

        private ISimpleCommand OkCommand { get; }
        private ISimpleCommand CancelCommand { get; }

        private TaskCompletionSource<bool> _TaskCompletionSource = new TaskCompletionSource<bool>();

        public MainModalViewModel(MessageInformation messageInformation) 
        {
            Title = messageInformation.Title;
            Message = messageInformation.Message;
            OkMessage = messageInformation.OkMessage;
            CancelMessage = messageInformation.CancelMessage;

            OkCommand = new RelaySimpleCommand(Ok);
            CancelCommand = new RelaySimpleCommand(Cancel);
        }

        private void Ok() => SetResult(true);

        private void Cancel() => SetResult(false);

        private void SetResult(bool value) 
        {
            if (_TaskCompletionSource.TrySetResult(value))
                Result = value;
        }
    }
}