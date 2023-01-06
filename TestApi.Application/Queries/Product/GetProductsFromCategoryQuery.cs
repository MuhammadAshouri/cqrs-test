using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Queries.Product;

[MediatorClass]
public class GetProductsFromCategoryQuery : IRequest<ICollection<Domain.Models.Product>>
{
    public int CategoryId { get; set; }
}