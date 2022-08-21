using System.Collections.Generic;
using System.Linq;
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
            var sectors = _sectorService.GetAllOrdered();
            return sectors.Select(x => new SectorViewModel
            {
                Code = x.Code,
                Name = x.Name
            }).ToList();
        }
    }
}