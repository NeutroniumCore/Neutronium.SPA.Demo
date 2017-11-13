using System.Threading.Tasks;

namespace Neutronium.SPA.Demo.ViewModel 
{
    public interface IConfirmationDisplayer 
    {
        Task<bool> ShowMessage(MessageInformation messageInformation);
    }
}