using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SectorApp.Data.Entities
{
    public class SectorUser
    {
        protected SectorUser()
        {
        }

        public SectorUser(string identityUserId)
        {
            IdentityUserId = identityUserId;
        }

        public Guid Id { get; set; }
        public Guid? SectorId { get; private set; }
        public string Name { get; private set; }
        public bool AgreeToTerms { get; private set; }
        
        public string IdentityUserId { get; private set; }
        public IdentityUser IdentityUser { get; private set; }
        public Sector Sector { get; private set; }

        public virtual void Update(string name, Guid sectorId, bool agreeToTerms)
        {
            Name = name;
            SectorId = sectorId;
            AgreeToTerms = agreeToTerms;
        }
    }
}