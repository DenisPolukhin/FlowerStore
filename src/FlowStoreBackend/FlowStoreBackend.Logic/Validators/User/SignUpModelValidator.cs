using FlowStoreBackend.Logic.Models.User;
using FluentValidation;

namespace FlowStoreBackend.Logic.Validators.User
{
    public class SignUpModelValidator : AbstractValidator<SignUpModel>
    {
        public SignUpModelValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .NotEmpty();
        }
    }
}
