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
                new Sector(4, "4", 1),
                new Sector(9, "9", 4),
                new Sector(10, "10", 4),
                new Sector(5, "5", 1),
                new Sector(2, "2"),
                new Sector(6, "6", 2),
                new Sector(7, "7", 2),
                new Sector(11, "11", 7),
                new Sector(12, "12", 7),
                new Sector(3, "3"),
                new Sector(8, "8", 3),
                new Sector(13, "13", 8),
            };
            _sectorServiceMock.Setup(m => m.GetAll()).Returns(sectors);
            
            // Act
            var result = _sut.ProvideModels();
            
            // Assert
            var expectedResult = new List<SectorViewModel>
            {
                new SectorViewModel{
                    Code = 1,
                    Name = "1",
                    SubSectors = new List<SectorViewModel>
                    {
                        new SectorViewModel{
                            Code = 4,
                            Name = "4",
                            SubSectors = new List<SectorViewModel>
                            {
                                new SectorViewModel{
                                    Code = 9,
                                    Name = "9",
                                    SubSectors = new List<SectorViewModel>()
                                },
                                new SectorViewModel{
                                    Code = 10,
                                    Name = "10",
                                    SubSectors = new List<SectorViewModel>()
                                },
                            }
                        },
                        new SectorViewModel{
                            Code = 5,
                            Name = "5",
                            SubSectors = new List<SectorViewModel>()
                        },
                    }
                },
                new SectorViewModel{
                    Code = 2,
                    Name = "2",
                    SubSectors = new List<SectorViewModel>
                    {
                        new SectorViewModel{
                            Code = 6,
                            Name = "6",
                            SubSectors = new List<SectorViewModel>()
                        },
                        new SectorViewModel{
                            Code = 7,
                            Name = "7",
                            SubSectors = new List<SectorViewModel>
                            {
                                new SectorViewModel{
                                    Code = 11,
                                    Name = "11",
                                    SubSectors = new List<SectorViewModel>()
                                },
                                new SectorViewModel{
                                    Code = 12,
                                    Name = "12",
                                    SubSectors = new List<SectorViewModel>()
                                },
                            }
                        },
                    }
                },
                new SectorViewModel{
                    Code = 3,
                    Name = "3",
                    SubSectors = new List<SectorViewModel>
                    {
                        new SectorViewModel{
                            Code = 8,
                            Name = "8",
                            SubSectors = new List<SectorViewModel>
                            {
                                new SectorViewModel{
                                    Code = 13,
                                    Name = "13",
                                    SubSectors = new List<SectorViewModel>()
                                },
                            }
                        },
                    }
                },
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}