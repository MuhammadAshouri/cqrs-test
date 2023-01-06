using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Queries.Product;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ICollection<Domain.Models.Product>>
{
    private readonly IRepository<Domain.Models.Product> Repository;
    public GetProductsQueryHandler(IUnitOfWork uow) => Repository = uow.GetRepository<Domain.Models.Product>();

    public async Task<ICollection<Domain.Models.Product>> Handle(GetProductsQuery request, CancellationToken ctoken) =>
        await Repository.Select().ToListAsync(cancellationToken: ctoken);
}