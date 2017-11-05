using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo.ViewModel
{
    public class MainViewModel
    {
        public string ApplicationName => "Neutronium Vuetify SPA";

        public IWindowViewModel Window { get; }

        public MainViewModel(WindowViewModel window)
        {
            Window = window;
        }
    }
}
