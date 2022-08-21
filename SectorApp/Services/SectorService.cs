﻿using System.Collections.Generic;
using System.Linq;
using SectorApp.Data;
using SectorApp.Data.Entities;

namespace SectorApp.Services
{
    public class SectorService : ISectorService
    {
        private readonly ApplicationDbContext _dbContext;

        public SectorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Sector> GetAllOrdered()
        {
            return _dbContext.Sectors.OrderBy(x => x.Code).ToList();
        }

        public Sector GetByCode(int code)
        {
            return _dbContext.Sectors.SingleOrDefault(x => x.Code == code);
        }
    }
}