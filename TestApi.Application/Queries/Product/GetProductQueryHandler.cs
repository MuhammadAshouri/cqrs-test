using MediatR;
using TestApi.Domain.Exceptions;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Queries.Product;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Domain.Models.Product>
{
    private readonly IRepository<Domain.Models.Product> Repository;
    public GetProductQueryHandler(IUnitOfWork uow) => Repository = uow.GetRepository<Domain.Models.Product>();

    public async Task<Domain.Models.Product> Handle(GetProductQuery request, CancellationToken ctoken) =>
        await Repository.GetById(request.Id) ?? throw new NotFoundException("Product", request.Id);
}