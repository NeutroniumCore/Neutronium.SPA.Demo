namespace Neutronium.SPA.Demo.ViewModel.BuildingBlock
{
    public class ItemViewModel : Vm.Tools.ViewModel
    {
        private bool _Done;
        public bool Done
        {
            get { return _Done; }
            set { Set(ref _Done, value); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { Set(ref _Name, value); }
        }

        public int Id { get; } = _ItemViewModelId++;

        private static int _ItemViewModelId = 0;
    }
}
