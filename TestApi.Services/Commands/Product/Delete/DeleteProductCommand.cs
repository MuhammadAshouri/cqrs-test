using MediatR;

namespace TestApi.Services.Commands.Product.Delete;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}