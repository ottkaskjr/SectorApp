using SectorApp.Models.Sector;

namespace SectorApp.Providers
{
    public interface IUpdateSectorViewModelProvider
    {
        UpdateSectorViewModel Provide(string userId);
        UpdateSectorViewModel ProvideFrom(UpdateSectorViewModel model);
    }
}