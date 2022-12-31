using MediatR;
using TestApi.Data.Interfaces;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;

namespace TestApi.Services.Commands.Category.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IMediator Mediator;
    private readonly ICategoryRepository Repository;
    private readonly IUnitOfWork UoW;

    public DeleteCategoryCommandHandler(IMediator mediator, ICategoryRepository repository, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = repository;
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
