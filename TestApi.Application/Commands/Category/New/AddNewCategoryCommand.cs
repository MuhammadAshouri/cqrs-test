using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Commands.Category.New;

[MediatorClass]
public class AddNewCategoryCommand : IRequest<int>
{
    public string Title { get; set; }
    public int? ParentId { get; set; }
}