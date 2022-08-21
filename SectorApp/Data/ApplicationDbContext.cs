using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SectorApp.Data.Entities;

namespace SectorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SectorUser> SectorUsers { get; set; }
    }
}
