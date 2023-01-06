using System.Text;
using MediatR;
using TestApi.Domain.Events;
using TestApi.Domain.Exceptions;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Commands.Category.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
{
    private readonly IMediator Mediator;
    private readonly IRepository<Domain.Models.Category> Repository;
    private readonly IUnitOfWork UoW;

    public UpdateCategoryCommandHandler(IMediator mediator, IUnitOfWork uow)
    {
        Mediator = mediator;
        Repository = uow.GetRepository<Domain.Models.Category>();
        UoW = uow;
    }

    public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryCommandValidator();
        var results = await validator.ValidateAsync(request, cancellationToken);
        var validationSucceeded = results.IsValid;
        if (!validationSucceeded)
        {
            var failures = results.Errors.ToList();
            var message = new StringBuilder();
            failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
            throw new ValidationException(message.ToString());
        }

        var product = await Repository.GetById(request.Id) ?? throw new NotFoundException("Category", request.Id);

        product.Title = request.Title;
        product.ParentId = request.ParentId;
        product.UpdateDate = DateTime.Now;

        Repository.Update(product);

        await UoW.Complete();

        await Mediator.Publish(new CategoryUpdated(product), cancellationToken);
        return 1;
    }
}