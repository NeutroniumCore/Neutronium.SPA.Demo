namespace Neutronium.SPA.Demo.ViewModel.Pages 
{
    public class AboutViewModel 
    {
        public string Nome => "About";

        public ApplicationInformation Information { get; } = new ApplicationInformation();
    }
}
