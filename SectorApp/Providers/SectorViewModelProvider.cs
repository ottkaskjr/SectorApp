using System.Collections.Generic;
using System.Linq;
using SectorApp.Data.Entities;
using SectorApp.Models.Sector;
using SectorApp.Services;

namespace SectorApp.Providers
{
    public class SectorViewModelProvider : ISectorViewModelProvider
    {
        private readonly ISectorService _sectorService;

        public SectorViewModelProvider(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        public List<SectorViewModel> ProvideModels()
        {
            var sectors = _sectorService.GetAll();
            return sectors
                .Where(s => s.ParentSectorCode == null)
                .Select(s => Map(s, sectors))
                .ToList();
        }

        private SectorViewModel Map(Sector sector, List<Sector> sectors)
        {
            return new SectorViewModel
            {
                Code = sector.Code,
                Name = sector.Name,
                SubSectors = sectors.Where(s => s.ParentSectorCode == sector.Code)
                    .Select(s => Map(s, sectors))
                    .ToList()
            };
        }
    }
}