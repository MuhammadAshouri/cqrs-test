using System.Text;
using MediatR;
using TestApi.Data.Interfaces;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;
using ValidationException = FluentValidation.ValidationException;

namespace TestApi.Services.Commands.Category.New;

public class AddNewCategoryCommandHandler : IRequestHandler<AddNewCategoryCommand, int>
{
    private readonly IMediator Mediator;
    private readonly ICategoryRepository Repository;
    private readonly IUnitOfWork UoW;

    public AddNewCategoryCommandHandler(IMediator mediator, ICategoryRepository repository, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = repository;
        UoW = uow;
    }

    public async Task<int> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddNewCategoryCommandValidator();
        var results = await validator.ValidateAsync(request, cancellationToken);
        var validationSucceeded = results.IsValid;
        if (!validationSucceeded)
        {
            var failures = results.Errors.ToList();
            var message = new StringBuilder();
            failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
            throw new ValidationException(message.ToString());
        }

        if (request.ParentId is > 0)
        {
            var parent = await Repository.First(c => c.Id == request.ParentId);
            if (parent?.ParentId is > 0)
            {
                var parent2 = await Repository.First(c => c.Id == parent.ParentId);
                if (parent2?.ParentId is > 0)
                {
                    var parent3 = await Repository.First(c => c.Id == parent2.ParentId);
                    if (parent3?.ParentId is > 0) throw new TooMuchLayerException("Category", request.Title);
                }
            }
        }

        var product = Repository.Add(new()
        {
            Title = request.Title.Trim(),
            ParentId = request.ParentId,
            AddDate = DateTime.Now,
            UpdateDate = DateTime.Now
        });

        await UoW.Complete();

        await Mediator.Publish(new CategoryCreated(product), cancellationToken);
        return 1;
    }
}
