using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SectorApp.Data;
using SectorApp.Data.Entities;
using SectorApp.Models.Sector;

namespace SectorApp.Services
{
    public class SectorUserService : ISectorUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISectorService _sectorService;

        public SectorUserService(ApplicationDbContext dbContext, ISectorService sectorService)
        {
            _dbContext = dbContext;
            _sectorService = sectorService;
        }

        public void CreateSectorUser(string userId)
        {
            var sectorUser = new SectorUser(userId);
            _dbContext.Add(sectorUser);
            _dbContext.SaveChanges();
        }

        public SectorUser Get(string userId)
        {
            return _dbContext.SectorUsers
                .Include(x => x.Sector)
                .SingleOrDefault(x => x.IdentityUserId == userId);
        }

        public void Update(string userId, UpdateSectorViewModel updateSectorViewModel)
        {
            if (updateSectorViewModel == null)
            {
                throw new ArgumentNullException(nameof(updateSectorViewModel));
            }

            var sectorUser = Get(userId);
            if (sectorUser == null)
            {
                throw new NullReferenceException(nameof(sectorUser));
            }

            var sector = _sectorService.GetByCode(updateSectorViewModel.SelectedSectorCode.Value);
            if (sector == null)
            {
                throw new NullReferenceException(nameof(sector));
            }
            
            sectorUser.Update(updateSectorViewModel.Name, sector.Id, updateSectorViewModel.AgreeToTerms);
            _dbContext.SaveChanges();
        }
    }
}