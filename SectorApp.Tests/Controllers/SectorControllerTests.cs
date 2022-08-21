using System;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SectorApp.Controllers;
using SectorApp.Models.Sector;
using SectorApp.Providers;
using SectorApp.Services;

namespace SectorApp.Tests.Controllers
{
    public class SectorControllerTests
    {
        private Mock<UserManager<IdentityUser>> _userManagerMock;
        private Mock<ISectorUserService> _sectorUserServiceMock;
        private Mock<IUpdateSectorViewModelProvider> _updateSectorViewModelProviderMock;
        private SectorController _sut;

        [SetUp]
        public void Setup()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            _sectorUserServiceMock = new Mock<ISectorUserService>(MockBehavior.Strict);
            _updateSectorViewModelProviderMock = new Mock<IUpdateSectorViewModelProvider>(MockBehavior.Strict);
            _sut = new SectorController(_userManagerMock.Object, _sectorUserServiceMock.Object, _updateSectorViewModelProviderMock.Object);
        }

        [Test]
        public void Controller_has_Authorize_attribute()
        {
            // Assert
            _sut.GetType().Should().BeDecoratedWith<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>();
        }
        
        [Test]
        public void Update_returns_view_and_model()
        {
            var userId = Guid.NewGuid().ToString();
            _userManagerMock.Setup(m => m.GetUserId(_sut.User))
                .Returns(userId);

            var model = Mock.Of<UpdateSectorViewModel>();
            _updateSectorViewModelProviderMock.Setup(m => m.Provide(userId))
                .Returns(model);
            
            // Act
            var result = (ViewResult) _sut.Update();
            
            // Assert
            result.Model.Should().BeEquivalentTo(model);
        }
        
        [Test]
        public void Update_POST_returns_view_and_model_if_ModelState_is_invalid()
        {
            var updateModel = Mock.Of<UpdateSectorViewModel>();
            var mappedModel = new UpdateSectorViewModel();
            _updateSectorViewModelProviderMock.Setup(m => m.ProvideFrom(updateModel))
                .Returns(mappedModel);

            // Act
            var result = (ViewResult) _sut.Update(updateModel);
            
            // Assert
            result.Model.Should().BeEquivalentTo(mappedModel);
            _sectorUserServiceMock.Verify(m => m.Update(It.IsAny<string>(), mappedModel), Times.Never);
        }
        
        [Test]
        public void Update_POST_updates_SectorUser_and_returns_view_and_model_if_ModelState_is_valid()
        {
            var updateModel = Mock.Of<UpdateSectorViewModel>();
            var mappedModel = new UpdateSectorViewModel
            {
                Name = "a",
                SelectedSectorCode = 1,
                AgreeToTerms = true
            };
            _updateSectorViewModelProviderMock.Setup(m => m.ProvideFrom(updateModel))
                .Returns(mappedModel);
            
            var userId = Guid.NewGuid().ToString();
            _userManagerMock.Setup(m => m.GetUserId(_sut.User))
                .Returns(userId);

            _sectorUserServiceMock.Setup(m => m.Update(userId, mappedModel));

            // Act
            var result = (ViewResult) _sut.Update(updateModel);
            
            // Assert
            result.Model.Should().BeEquivalentTo(mappedModel);
            _sut.ViewData["SectorUpdateSuccess"].Should().Be("Sector information has been updated");
            _sectorUserServiceMock.Verify(m => m.Update(It.IsAny<string>(), mappedModel), Times.Once);
        }
    }
}