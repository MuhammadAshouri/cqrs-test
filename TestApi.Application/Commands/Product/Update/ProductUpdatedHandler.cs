using MediatR;
using Microsoft.Extensions.Logging;
using TestApi.Domain.Events;

namespace TestApi.Application.Commands.Product.Update;

public class ProductUpdatedHandler : INotificationHandler<ProductUpdated>
{
    private readonly ILogger<ProductUpdatedHandler> Logger;

    public ProductUpdatedHandler(ILogger<ProductUpdatedHandler> logger) => Logger = logger;

    public Task Handle(ProductUpdated notification, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Product {Va} was updated", notification.NewProduct.Id);
        return Task.CompletedTask;
    }
}