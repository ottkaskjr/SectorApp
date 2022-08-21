using System;

namespace SectorApp.Data.Entities
{
    public class Sector
    {
        protected Sector()
        {
        }

        public Sector(int code, string name)
        {
            Code = code;
            Name = name.Trim();
        }

        public Guid Id { get; set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
    }
}