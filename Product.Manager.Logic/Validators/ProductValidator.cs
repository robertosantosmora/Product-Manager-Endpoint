using FluentValidation;
using Entities = Product.Manager.Data.Entities;

namespace Product.Manager.Logic.Validators;

public class ProductValidator :AbstractValidator<Entities.Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Product code not valid");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name not valid");
    }
}
