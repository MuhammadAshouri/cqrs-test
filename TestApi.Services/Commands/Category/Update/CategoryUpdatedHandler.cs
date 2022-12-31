using MediatR;
using Microsoft.Extensions.Logging;
using TestApi.Domain.Events;

namespace TestApi.Services.Commands.Category.Update;

public class CategoryUpdatedHandler : INotificationHandler<CategoryUpdated>
{
    private readonly ILogger<CategoryUpdatedHandler> Logger;

    public CategoryUpdatedHandler(ILogger<CategoryUpdatedHandler> logger) => Logger = logger;

    public Task Handle(CategoryUpdated notification, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Category {Va} was updated", notification.NewCategory.Id);
        return Task.CompletedTask;
    }
}
