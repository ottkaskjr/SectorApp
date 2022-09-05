using System;

namespace SectorApp.Data.Entities
{
    public class Sector
    {
        protected Sector()
        {
        }

        public Sector(int code, string name, int? parentSectorCode = null)
        {
            Code = code;
            Name = name.Trim();
            ParentSectorCode = parentSectorCode;
        }

        public Guid Id { get; set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int? ParentSectorCode { get; private set; }
        public virtual Sector ParentSector { get; private set; }
    }
}