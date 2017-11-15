using System.Threading.Tasks;

namespace Neutronium.SPA.Demo.Application.WindowServices
{
    public interface IMessageBox 
    {
        Task<bool> ShowMessage(ConfirmationMessage confirmationMessage);

        void ShowInformation(MessageInformation messageInformation);
    }
}