using FluentValidation;

namespace TestApi.Application.Commands.Product.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Id).GreaterThan(0).WithMessage("Invalid product");
        RuleFor(p => p.Title).NotEmpty().WithMessage("Product title must be specified").MinimumLength(3)
            .WithMessage("Product title must have at least 3 characters")
            .MaximumLength(100).WithMessage("Product title exceeds 100 characters");
        RuleFor(p => p.Price).GreaterThanOrEqualTo(1000).WithMessage("Product price must be at least 1000");
        RuleFor(p => p.CategoryId).GreaterThan(0).WithMessage("Select a valid category");
        RuleFor(p => p.Properties).NotEmpty().WithMessage("Add at least one property");
    }
}