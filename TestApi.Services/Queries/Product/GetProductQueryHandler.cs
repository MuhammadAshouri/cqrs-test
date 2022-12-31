using MediatR;
using TestApi.Data.Interfaces;
using TestApi.Domain.Exceptions;

namespace TestApi.Services.Queries.Product;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Domain.Models.Product>
{
    private readonly IProductRepository Repository;

    public GetProductQueryHandler(IProductRepository repository) => Repository = repository;

    public async Task<Domain.Models.Product> Handle(GetProductQuery request, CancellationToken ctoken) =>
        await Repository.GetById(request.Id) ?? throw new NotFoundException("Product", request.Id);
}
