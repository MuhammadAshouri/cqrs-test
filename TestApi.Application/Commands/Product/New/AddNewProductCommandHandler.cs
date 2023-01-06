using System.Text;
using FluentValidation;
using MediatR;
using TestApi.Domain.Events;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Commands.Product.New;

public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, int>
{
    private readonly IMediator Mediator;
    private readonly IRepository<Domain.Models.Product> Repository;
    private readonly IUnitOfWork UoW;

    public AddNewProductCommandHandler(IMediator mediator, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = uow.GetRepository<Domain.Models.Product>();
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