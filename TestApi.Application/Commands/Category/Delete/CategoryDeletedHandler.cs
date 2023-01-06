using MediatR;
using Microsoft.Extensions.Logging;
using TestApi.Domain.Events;

namespace TestApi.Application.Commands.Category.Delete;

public class CategoryDeletedHandler : INotificationHandler<CategoryDeleted>
{
    private readonly ILogger<CategoryDeletedHandler> Logger;

    public CategoryDeletedHandler(ILogger<CategoryDeletedHandler> logger) => Logger = logger;

    public Task Handle(CategoryDeleted notification, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Category {Va} was deleted from db", notification.DeletedCategory.Title);
        return Task.CompletedTask;
    }
}