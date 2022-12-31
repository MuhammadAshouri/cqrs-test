using System.Text;
using MediatR;
using TestApi.Data.Interfaces;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;

namespace TestApi.Services.Commands.Product.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IMediator Mediator;
    private readonly IProductRepository Repository;
    private readonly IUnitOfWork UoW;

    public UpdateProductCommandHandler(IMediator mediator, IProductRepository repository, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = repository;
        UoW = uow;
    }

    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var results = await validator.ValidateAsync(request, cancellationToken);
        var validationSucceeded = results.IsValid;
        if (!validationSucceeded)
        {
            var failures = results.Errors.ToList();
            var message = new StringBuilder();
            failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
            throw new ValidationException(message.ToString());
        }

        var product = await Repository.GetById(request.Id) ?? throw new NotFoundException("Product", request.Id);

        product.Title = request.Title;
        product.Price = request.Price;
        product.UpdateDate = DateTime.Now;
        product.CategoryId = request.CategoryId;
        product.Properties = request.Properties;

        Repository.Update(product);

        await UoW.Complete();

        await Mediator.Publish(new ProductUpdated(product), cancellationToken);
        return 1;
    }
}
