using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.Infrastructure.Interfaces;

namespace TestApi.Application.Queries.Category;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Domain.Models.Category>>
{
    private readonly IRepository<Domain.Models.Category> Repository;
    public GetCategoriesQueryHandler(IUnitOfWork uow) => Repository = uow.GetRepository<Domain.Models.Category>();

    public Task<IEnumerable<Domain.Models.Category>> Handle(GetCategoriesQuery request, CancellationToken ctoken) =>
        Task.FromResult(Repository.Where(c => request.Id.HasValue ? c.Id == request.Id : !c.ParentId.HasValue).AsNoTracking().Include(c => c.Childs)
            .ThenInclude(c => c.Childs).ThenInclude(c => c.Childs).AsParallel().AsEnumerable());
}