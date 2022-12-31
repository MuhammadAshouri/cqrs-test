using MediatR;
using Microsoft.Extensions.Logging;
using TestApi.Domain.Events;

namespace TestApi.Services.Commands.Product.Delete;

public class ProductDeletedHandler : INotificationHandler<ProductDeleted>
{
    private readonly ILogger<ProductDeletedHandler> Logger;

    public ProductDeletedHandler(ILogger<ProductDeletedHandler> logger) => Logger = logger;

    public Task Handle(ProductDeleted notification, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Product {Va} was deleted from db", notification.DeletedProduct.Title);
        return Task.CompletedTask;
    }
}
