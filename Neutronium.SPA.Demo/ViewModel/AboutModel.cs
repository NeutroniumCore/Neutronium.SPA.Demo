using Neutronium.BuildingBlocks.Application.ViewModels;

namespace Neutronium.SPA.Demo.ViewModel
{
    public class AboutViewModel
    {
        public ApplicationInformation Information { get; } = new ApplicationInformation("Neutronium Demo", "David Desmaisons");

        public string[] Descriptions { get; } =
        {
            Resource.About1,
            Resource.About2,
            Resource.About3
        };
    }
}
