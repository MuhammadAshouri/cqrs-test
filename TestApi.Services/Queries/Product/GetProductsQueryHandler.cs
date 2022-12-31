using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.Data.Interfaces;

namespace TestApi.Services.Queries.Product;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ICollection<Domain.Models.Product>>
{
    private readonly IProductRepository Repository;

    public GetProductsQueryHandler(IProductRepository repository) => Repository = repository;

    public async Task<ICollection<Domain.Models.Product>> Handle(GetProductsQuery request, CancellationToken ctoken) =>
        await Repository.Select().ToListAsync(cancellationToken: ctoken);
}
