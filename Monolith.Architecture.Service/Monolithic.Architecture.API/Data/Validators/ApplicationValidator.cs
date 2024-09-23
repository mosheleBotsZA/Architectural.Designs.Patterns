using FluentValidation;
using Monolithic.Architecture.API.Data.Models.Applications;

namespace Monolithic.Architecture.API.Data.Validators
{
    public class ApplicationValidator : AbstractValidator<Application>
    {
        public ApplicationValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.CategoryId).NotEmpty();
            RuleFor(c => c.CreatedDate).GreaterThanOrEqualTo(c => c.ClosingDate);
        }
    }
}