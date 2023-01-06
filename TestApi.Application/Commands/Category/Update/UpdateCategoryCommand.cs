using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Commands.Category.Update;

[MediatorClass]
public class UpdateCategoryCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? ParentId { get; set; }
}