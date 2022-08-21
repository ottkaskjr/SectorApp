using System.Collections.Generic;
using SectorApp.Data.Entities;

namespace SectorApp.Services
{
    public interface ISectorService
    {
        List<Sector> GetAllOrdered();
        Sector GetByCode(int code);
    }
}