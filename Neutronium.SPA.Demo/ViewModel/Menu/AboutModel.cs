namespace Neutronium.SPA.Demo.ViewModel.Menu 
{
    public class AboutViewModel 
    {
        public string Nome => "About";

        public ApplicationInformation Information { get; } = new ApplicationInformation();
    }
}
