using System.Text;
using FluentValidation;
using MediatR;
using TestApi.Data.Interfaces;
using TestApi.Domain.Events;

namespace TestApi.Services.Commands.Product.New;

public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, int>
{
    private readonly IMediator Mediator;
    private readonly IProductRepository Repository;
    private readonly IUnitOfWork UoW;

    public AddNewProductCommandHandler(IMediator mediator, IProductRepository repository, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = repository;
        UoW = uow;
    }

    public async Task<int> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddNewProductCommandValidator();
        var results = await validator.ValidateAsync(request, cancellationToken);
        var validationSucceeded = results.IsValid;
        if (!validationSucceeded)
        {
            var failures = results.Errors.ToList();
            var message = new StringBuilder();
            failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
            throw new ValidationException(message.ToString());
        }

        var product = Repository.Add(new()
        {
            Title = request.Title,
            Price = request.Price,
            CategoryId = request.CategoryId,
            AddDate = DateTime.Now,
            UpdateDate = DateTime.Now,
            Properties = request.Properties
        });

        await UoW.Complete();

        await Mediator.Publish(new ProductCreated(product), cancellationToken);
        return 1;
    }
}
