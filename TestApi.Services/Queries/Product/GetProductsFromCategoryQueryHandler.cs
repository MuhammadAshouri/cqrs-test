using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.Data.Interfaces;

namespace TestApi.Services.Queries.Product;

public class GetProductsFromCategoryQueryHandler : IRequestHandler<GetProductsFromCategoryQuery, ICollection<Domain.Models.Product>>
{
    private readonly IProductRepository Repository;

    public GetProductsFromCategoryQueryHandler(IProductRepository repository) => Repository = repository;

    public async Task<ICollection<Domain.Models.Product>> Handle(GetProductsFromCategoryQuery request, CancellationToken ctoken) =>
        await Repository.Where(c => c.CategoryId == request.CategoryId).ToListAsync(ctoken);
}
