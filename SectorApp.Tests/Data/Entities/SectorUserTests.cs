using System;
using FluentAssertions;
using NUnit.Framework;
using SectorApp.Data.Entities;

namespace SectorApp.Tests.Data.Entities
{
    public class SectorUserTests
    {
        [Test]
        public void Update_updates_Name_and_SectorId_and_AgreeToTerms()
        {
            var sut = new SectorUser("userId");
            var sectorId = Guid.NewGuid();

            // Act
            sut.Update("name", sectorId, true);
            
            // Assert
            sut.Name.Should().Be("name");
            sut.SectorId.Should().Be(sectorId);
            sut.AgreeToTerms.Should().Be(true);
        }
    }
}