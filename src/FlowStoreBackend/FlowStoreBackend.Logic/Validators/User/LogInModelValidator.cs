using FlowStoreBackend.Logic.Models.User;
using FluentValidation;

namespace FlowStoreBackend.Logic.Validators.User
{
    public class LogInModelValidator : AbstractValidator<LogInModel>
    {
        public LogInModelValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .NotEmpty();
        }
    }
}