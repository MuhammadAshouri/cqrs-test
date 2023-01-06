using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Queries.Product;

public class GetProductsFromCategoryQueryHandler : IRequestHandler<GetProductsFromCategoryQuery, ICollection<Domain.Models.Product>>
{
    private readonly IRepository<Domain.Models.Product> Repository;
    public GetProductsFromCategoryQueryHandler(IUnitOfWork uow) => Repository = uow.GetRepository<Domain.Models.Product>();

    public async Task<ICollection<Domain.Models.Product>> Handle(GetProductsFromCategoryQuery request, CancellationToken ctoken) =>
        await Repository.Where(c => c.CategoryId == request.CategoryId).ToListAsync(ctoken);
}