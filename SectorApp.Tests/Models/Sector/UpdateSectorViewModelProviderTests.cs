using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SectorApp.Data.Entities;
using SectorApp.Models.Sector;
using SectorApp.Providers;
using SectorApp.Services;

namespace SectorApp.Tests.Validators
{
    public class UpdateSectorViewModelProviderTests
    {
        private Mock<ISectorUserService> _sectorUserServiceMock;
        private Mock<ISectorViewModelProvider> _sectorViewModelProviderMock;
        private UpdateSectorViewModelProvider _sut;

        [SetUp]
        public void Setup()
        {
            _sectorUserServiceMock = new Mock<ISectorUserService>(MockBehavior.Strict);
            _sectorViewModelProviderMock = new Mock<ISectorViewModelProvider>(MockBehavior.Strict);
            _sut = new UpdateSectorViewModelProvider(_sectorUserServiceMock.Object, _sectorViewModelProviderMock.Object);
        }

        [Test]
        public void Provide_throws_if_sectorUser_is_null()
        {
            var userId = "userId";
            _sectorUserServiceMock.Setup(m => m.Get(userId)).Returns((SectorUser)null);
            Action testException = () => { _sut.Provide(userId); };
            
            // Act, assert
            testException.Should().Throw<NullReferenceException>().WithMessage("sectorUser");
        }
        
        [Test]
        public void Provide_maps_and_returns_model_if_sectorUser_is_NOT_null()
        {
            var userId = "userId";
            var sectorUser = new SectorUser(userId);
            var sectorId = Guid.NewGuid();
            sectorUser.Update("name", sectorId, true);
            _sectorUserServiceMock.Setup(m => m.Get(userId)).Returns(sectorUser);

            var sectorModels = new List<SectorViewModel>
            {
                Mock.Of<SectorViewModel>(),
                Mock.Of<SectorViewModel>(),
                Mock.Of<SectorViewModel>(),
            };
            _sectorViewModelProviderMock.Setup(m => m.ProvideModels()).Returns(sectorModels);
            
            // Act
            var result = _sut.Provide(userId);
            
            // Assert
            var expectedResult = new UpdateSectorViewModel
            {
                Name = "name",
                Sectors = sectorModels,
                SelectedSectorCode = null,
                AgreeToTerms = true,
            };
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test] 
        public void ProvideFrom_throws_if_model_is_null()
        {
            Action testException = () => { _sut.ProvideFrom(model: null); };
            
            // Act, assert
            testException.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'model')");
        }
        
        [Test]
        public void ProvideFrom_maps_and_returns_model_if_model_is_NOT_null()
        {
            var model = new UpdateSectorViewModel
            {
                Name = "name",
                SelectedSectorCode = 1,
                AgreeToTerms = false,
            };

            var sectorModels = new List<SectorViewModel>
            {
                Mock.Of<SectorViewModel>(),
                Mock.Of<SectorViewModel>(),
                Mock.Of<SectorViewModel>(),
            };
            _sectorViewModelProviderMock.Setup(m => m.ProvideModels()).Returns(sectorModels);
            
            // Act
            var result = _sut.ProvideFrom(model);
            
            // Assert
            var expectedResult = new UpdateSectorViewModel
            {
                Name = "name",
                Sectors = sectorModels,
                SelectedSectorCode = 1,
                AgreeToTerms = false,
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}