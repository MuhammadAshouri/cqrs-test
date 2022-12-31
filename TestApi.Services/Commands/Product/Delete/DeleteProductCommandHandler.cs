using MediatR;
using TestApi.Data.Interfaces;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;

namespace TestApi.Services.Commands.Product.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IMediator Mediator;
    private readonly IProductRepository Repository;
    private readonly IUnitOfWork UoW;

    public DeleteProductCommandHandler(IMediator mediator, IProductRepository repository, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = repository;
        UoW = uow;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await Repository.GetById(request.Id) ?? throw new NotFoundException("Product", request.Id);
        Repository.Remove(product);
        var result = await UoW.Complete();
        if (!result) throw new SaveChangesException("Product", request.Id);

        await Mediator.Publish(new ProductDeleted(product), cancellationToken);
        return Unit.Value;
    }
}
