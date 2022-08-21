using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SectorApp.Data.Entities;
using SectorApp.Models.Sector;
using SectorApp.Providers;
using SectorApp.Services;

namespace SectorApp.Tests.Providers
{
    public class SectorViewModelProviderTests
    {
        private Mock<ISectorService> _sectorServiceMock;
        private SectorViewModelProvider _sut;

        [SetUp]
        public void Setup()
        {
            _sectorServiceMock = new Mock<ISectorService>(MockBehavior.Strict);
            _sut = new SectorViewModelProvider(_sectorServiceMock.Object);
        }

        [Test]
        public void ProvideModels_maps_and_returns_SectorViewModels()
        {
            var sectors = new List<Sector>
            {
                new Sector(1, "1"),
                new Sector(2, "2"),
                new Sector(3, "3"),
            };
            _sectorServiceMock.Setup(m => m.GetAllOrdered()).Returns(sectors);
            
            // Act
            var result = _sut.ProvideModels();
            
            // Assert
            var expectedResult = new List<SectorViewModel>
            {
                new SectorViewModel{
                    Code = 1,
                    Name = "1"
                },
                new SectorViewModel{
                    Code = 2,
                    Name = "2"
                },
                new SectorViewModel{
                    Code = 3,
                    Name = "3"
                },
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}