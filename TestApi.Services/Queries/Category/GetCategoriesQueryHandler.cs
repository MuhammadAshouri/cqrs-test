using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.Data.Interfaces;

namespace TestApi.Services.Queries.Category;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Domain.Models.Category>>
{
    private readonly ICategoryRepository Repository;

    public GetCategoriesQueryHandler(ICategoryRepository repository) => Repository = repository;

    public Task<IEnumerable<Domain.Models.Category>> Handle(GetCategoriesQuery request, CancellationToken ctoken) =>
        Task.FromResult(Repository.Where(c => request.Id.HasValue ? c.Id == request.Id : !c.ParentId.HasValue).AsNoTracking().Include(c => c.Childs)
            .ThenInclude(c => c.Childs).ThenInclude(c => c.Childs).AsParallel().AsEnumerable());
}
