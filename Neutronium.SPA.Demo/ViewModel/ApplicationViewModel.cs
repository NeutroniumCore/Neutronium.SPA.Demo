using System;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo.ViewModel
{
    public class ApplicationViewModel : Vm.Tools.ViewModel
    {
        public ApplicationInformation ApplicationInformation { get; } = new ApplicationInformation();
        public IWindowViewModel Window { get; }
        public IResultCommand NavigateCommand { get; }

        private Vm.Tools.ViewModel _CurrentViewModel;
        public Vm.Tools.ViewModel CurrentViewModel 
        {
            get { return _CurrentViewModel; }
            set { Set(ref _CurrentViewModel, value); }
        }

        public ApplicationViewModel(WindowViewModel window)
        {
            Window = window;
            NavigateCommand = RelayResultCommand.Create<string,bool>(Navigate);
        }

        private bool Navigate(string path)
        {
            Console.WriteLine(path);
            return true;
        }
    }
}
