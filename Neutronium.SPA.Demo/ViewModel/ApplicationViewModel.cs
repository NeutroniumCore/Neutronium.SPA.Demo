using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo.ViewModel
{
    public class ApplicationViewModel : Vm.Tools.ViewModel
    {
        public ApplicationInformation ApplicationInformation { get; } = new ApplicationInformation();

        public IWindowViewModel Window { get; }

        public ApplicationViewModel(WindowViewModel window)
        {
            Window = window;
        }
    }
}
