using FluentValidation;

namespace TestApi.Application.Commands.Category.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(p => p.Id).GreaterThan(0).WithMessage("Invalid category");
        RuleFor(p => p.Title).NotEmpty().WithMessage("Category title must be specified").MinimumLength(3)
            .WithMessage("Category title must have at least 3 characters")
            .MaximumLength(100).WithMessage("Category title exceeds 100 characters");
    }
}