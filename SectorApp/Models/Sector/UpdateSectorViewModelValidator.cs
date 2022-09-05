using FluentValidation;

namespace SectorApp.Models.Sector
{
    public class UpdateSectorViewModelValidator : AbstractValidator<UpdateSectorViewModel>
    {
        public UpdateSectorViewModelValidator()
        {
            RuleFor(m => m.Name).NotNull().WithMessage("Name is required!");
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(m => m.Name).MaximumLength(50).WithMessage("Name cannot be longer than 50 characters!");
            RuleFor(m => m.SelectedSectorCode).NotNull().WithMessage("Sector is required!");
            RuleFor(m => m.AgreeToTerms).Must(agreeToTerms => agreeToTerms).WithMessage("You must agree to terms!");
        }
    }
}