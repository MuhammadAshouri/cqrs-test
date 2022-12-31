using MediatR;

namespace TestApi.Services.Queries.Product;

public class GetProductQuery : IRequest<Domain.Models.Product>
{
    public int Id { get; set; }
}
