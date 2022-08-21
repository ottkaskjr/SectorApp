using FluentAssertions;
using NUnit.Framework;
using SectorApp.Models.Sector;

namespace SectorApp.Tests.Models.Sector
{
    public class UpdateSectorViewModelValidatorTests
    {
        private UpdateSectorViewModelValidator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new UpdateSectorViewModelValidator();
        }

        private static UpdateSectorViewModel[] _invalidModels = new[]
        {
            new UpdateSectorViewModel(),
            new UpdateSectorViewModel
            {
                SelectedSectorCode = 1,
                AgreeToTerms = true
            },
            new UpdateSectorViewModel
            {
                Name = "",
                SelectedSectorCode = 1,
                AgreeToTerms = true
            },
            new UpdateSectorViewModel
            {
                Name = "a",
                AgreeToTerms = true
            },
            new UpdateSectorViewModel
            {
                Name = "a",
                SelectedSectorCode = 1,
            },
        };

        [TestCaseSource(nameof(_invalidModels))]
        public void Required_properties_do_not_allow_empty_or_invalid_values(UpdateSectorViewModel model)
        {
            // Act
            var result = _sut.Validate(model);
            
            // Assert
            result.IsValid.Should().BeFalse();
        }
        
        [Test]
        public void Model_is_valid_if_all_required_properties_are_valid()
        {
            var model = new UpdateSectorViewModel
            {
                Name = "a",
                SelectedSectorCode = 1,
                AgreeToTerms = true
            };
            
            // Act
            var result = _sut.Validate(model);
            
            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}