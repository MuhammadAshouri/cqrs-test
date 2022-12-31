using MediatR;

namespace TestApi.Services.Queries.Product;

public class GetProductsFromCategoryQuery : IRequest<ICollection<Domain.Models.Product>>
{
    public int CategoryId { get; set; }
}
