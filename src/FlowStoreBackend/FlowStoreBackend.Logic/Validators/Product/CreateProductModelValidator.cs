using FlowStoreBackend.Logic.Models.Product;
using FluentValidation;

namespace FlowStoreBackend.Logic.Validators.Product
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2);

            RuleFor(x => x.Description)
                .MinimumLength(2);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(1);
        }
    }
}
