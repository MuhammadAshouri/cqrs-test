using MediatR;
using Microsoft.Extensions.Logging;
using TestApi.Domain.Events;

namespace TestApi.Services.Commands.Category.New;

public class NewCategoryCreatedHandler : INotificationHandler<CategoryCreated>
{
    private readonly ILogger<NewCategoryCreatedHandler> Logger;

    public NewCategoryCreatedHandler(ILogger<NewCategoryCreatedHandler> logger) => Logger = logger;

    public Task Handle(CategoryCreated notification, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Category {Va} was added to db", notification.NewCategory.Id);
        return Task.CompletedTask;
    }
}
