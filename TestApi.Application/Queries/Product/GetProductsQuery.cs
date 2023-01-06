using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Queries.Product;

[MediatorClass]
public class GetProductsQuery : IRequest<ICollection<Domain.Models.Product>>
{
}