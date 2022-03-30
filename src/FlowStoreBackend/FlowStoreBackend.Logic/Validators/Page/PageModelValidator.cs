using FlowStoreBackend.Logic.Models.Page;
using FluentValidation;

namespace FlowStoreBackend.Logic.Validators.Page
{
    public class PageModelValidator : AbstractValidator<PageModel>
    {
        public PageModelValidator()
        {
            RuleFor(x => x.Index)
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.Size)
                .GreaterThanOrEqualTo(18);
        }
    }
}
