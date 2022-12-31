using MediatR;

namespace TestApi.Services.Queries.Product;

public class GetProductsQuery : IRequest<ICollection<Domain.Models.Product>>
{
    
}
