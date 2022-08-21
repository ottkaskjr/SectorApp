using System;
using SectorApp.Models.Sector;
using SectorApp.Services;

namespace SectorApp.Providers
{
    public class UpdateSectorViewModelProvider : IUpdateSectorViewModelProvider
    {
        private readonly ISectorUserService _sectorUserService;
        private readonly ISectorViewModelProvider _sectorViewModelProvider;

        public UpdateSectorViewModelProvider(ISectorUserService sectorUserService,
            ISectorViewModelProvider sectorViewModelProvider)
        {
            _sectorUserService = sectorUserService;
            _sectorViewModelProvider = sectorViewModelProvider;
        }

        public UpdateSectorViewModel Provide(string userId)
        {
            var sectorUser = _sectorUserService.Get(userId);
            if (sectorUser == null)
            {
                throw new NullReferenceException($"{nameof(sectorUser)}");
            }
            
            return new UpdateSectorViewModel
            {
                Name = sectorUser.Name,
                Sectors = _sectorViewModelProvider.ProvideModels(),
                SelectedSectorCode = sectorUser.Sector?.Code,
                AgreeToTerms = sectorUser.AgreeToTerms
            };
        }

        public UpdateSectorViewModel ProvideFrom(UpdateSectorViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"{nameof(model)}");
            }
            
            return new UpdateSectorViewModel
            {
                Name = model.Name,
                Sectors = _sectorViewModelProvider.ProvideModels(),
                SelectedSectorCode = model.SelectedSectorCode,
                AgreeToTerms = model.AgreeToTerms
            };
        }
    }
}