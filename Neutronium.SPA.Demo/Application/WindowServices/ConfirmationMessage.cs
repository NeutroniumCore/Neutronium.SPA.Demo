namespace Neutronium.SPA.Demo.Application.WindowServices
{
    public class ConfirmationMessage : MessageInformation
    {
        public string CancelMessage { get; }

        public ConfirmationMessage(string title, string message):base(title, message)
        {
            CancelMessage = Resource.Cancel;
        }

        public ConfirmationMessage(string title, string message, string okMessage, string cancelMessage) : base(title, message, okMessage)
        {
            CancelMessage = cancelMessage;
        }
    }
}