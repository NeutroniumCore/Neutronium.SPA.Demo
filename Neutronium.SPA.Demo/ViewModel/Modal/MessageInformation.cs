namespace Neutronium.SPA.Demo.ViewModel 
{
    public struct MessageInformation 
    {
        public string CancelMessage { get; }
        public string Message { get; }
        public string OkMessage { get; }
        public string Title { get; }

        public MessageInformation(string title, string message)
        {
            Title = title;
            Message = message;
            OkMessage = "Ok";
            CancelMessage = "Cancel";
        }
        public MessageInformation(string title, string message, string okMessage, string cancelMessage) 
        {
            Title = title;
            Message = message;
            OkMessage = okMessage;
            CancelMessage = cancelMessage;
        }
    }
}