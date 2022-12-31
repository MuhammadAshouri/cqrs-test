using MediatR;
using TestApi.Domain.Models;

namespace TestApi.Services.Queries.Category;

public class GetCategoriesQuery : IRequest<IEnumerable<Domain.Models.Category>>
{
    public int? Id { get; set; }
}
