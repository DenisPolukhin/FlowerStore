using FlowStoreBackend.Logic.Models.User;
using FluentValidation;

namespace FlowStoreBackend.Logic.Validators.User
{
    public class UpdateUserProfileModelValidator : AbstractValidator<UpdateUserProfileModel>
    {
        public UpdateUserProfileModelValidator()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .Unless(x => string.IsNullOrEmpty(x.FirstName))
                .NotEmpty();

            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .Unless(x => string.IsNullOrEmpty(x.LastName))
                .NotEmpty();

            RuleFor(x => x.MiddleName)
                .MinimumLength(2)
                .Unless(x => string.IsNullOrEmpty(x.MiddleName))
                .NotEmpty();
        }
    }
}
