namespace Neutronium.SPA.Demo.ViewModel.Common
{
    public class ItemViewModel : BuildingBlocks.ViewModel
    {
        private bool _Done;
        public bool Done
        {
            get => _Done;
            set => Set(ref _Done, value);
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        public int Id { get; } = _ItemViewModelId++;

        private static int _ItemViewModelId = 0;
    }
}
