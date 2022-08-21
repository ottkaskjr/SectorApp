using SectorApp.Data.Entities;
using SectorApp.Models.Sector;

namespace SectorApp.Services
{
    public interface ISectorUserService
    {
        void CreateSectorUser(string userId);
        SectorUser Get(string userId);
        void Update(string userId, UpdateSectorViewModel updateSectorViewModel);
    }
}