using System.Collections.Generic;
using SectorApp.Models.Sector;

namespace SectorApp.Providers
{
    public interface ISectorViewModelProvider
    {
        List<SectorViewModel> ProvideModels();
    }
}