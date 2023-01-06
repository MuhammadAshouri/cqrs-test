using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Commands.Product.Delete;

[MediatorClass]
public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}