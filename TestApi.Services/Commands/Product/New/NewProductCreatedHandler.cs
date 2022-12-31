using MediatR;
using Microsoft.Extensions.Logging;
using TestApi.Domain.Events;

namespace TestApi.Services.Commands.Product.New;

public class NewProductCreatedHandler : INotificationHandler<ProductCreated>
{
    private readonly ILogger<NewProductCreatedHandler> Logger;

    public NewProductCreatedHandler(ILogger<NewProductCreatedHandler> logger) => Logger = logger;

    public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
        Logger.LogInformation("Product {Va} was added to db", notification.NewProduct.Id);
        return Task.CompletedTask;
    }
}
