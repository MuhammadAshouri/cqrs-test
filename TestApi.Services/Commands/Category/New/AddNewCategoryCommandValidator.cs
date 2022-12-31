using FluentValidation;

namespace TestApi.Services.Commands.Category.New;

public class AddNewCategoryCommandValidator : AbstractValidator<AddNewCategoryCommand>
{
    public AddNewCategoryCommandValidator() =>
        RuleFor(p => p.Title).NotEmpty().WithMessage("Category title must be specified").MinimumLength(3)
            .WithMessage("Category title must have at least 3 characters")
            .MaximumLength(100).WithMessage("Category title exceeds 100 characters");
}