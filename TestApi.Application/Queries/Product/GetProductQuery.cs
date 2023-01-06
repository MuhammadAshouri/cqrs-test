using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Queries.Product;

[MediatorClass]
public class GetProductQuery : IRequest<Domain.Models.Product>
{
    public int Id { get; set; }
}