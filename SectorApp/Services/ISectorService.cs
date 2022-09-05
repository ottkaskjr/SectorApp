using System.Collections.Generic;
using SectorApp.Data.Entities;

namespace SectorApp.Services
{
    public interface ISectorService
    {
        List<Sector> GetAll();
        Sector GetByCode(int code);
    }
}