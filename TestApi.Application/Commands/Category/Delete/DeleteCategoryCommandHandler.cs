using MediatR;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Commands.Category.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IMediator Mediator;
    private readonly IRepository<Domain.Models.Category> Repository;
    private readonly IUnitOfWork UoW;

    public DeleteCategoryCommandHandler(IMediator mediator, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = uow.GetRepository<Domain.Models.Category>();
        UoW = uow;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await Repository.GetById(request.Id) ?? throw new NotFoundException("Category", request.Id);
        Repository.Remove(category);
        var result = await UoW.Complete();
        if (!result) throw new SaveChangesException("Category", request.Id);

        await Mediator.Publish(new CategoryDeleted(category), cancellationToken);
        return Unit.Value;
    }
}