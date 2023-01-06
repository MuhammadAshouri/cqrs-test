using MediatR;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Commands.Product.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IMediator Mediator;
    private readonly IRepository<Domain.Models.Product> Repository;
    private readonly IUnitOfWork UoW;

    public DeleteProductCommandHandler(IMediator mediator, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = uow.GetRepository<Domain.Models.Product>();
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