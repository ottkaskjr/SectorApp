using System.Collections.Generic;

namespace SectorApp.Models.Sector
{
    public class SectorViewModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<SectorViewModel> SubSectors { get; set; }
    }
}