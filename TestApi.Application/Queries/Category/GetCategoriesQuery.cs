using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Queries.Category;

[MediatorClass]
public class GetCategoriesQuery : IRequest<IEnumerable<Domain.Models.Category>>
{
    public int? Id { get; set; }
}