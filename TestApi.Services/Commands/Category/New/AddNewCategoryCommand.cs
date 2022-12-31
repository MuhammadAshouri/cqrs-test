using MediatR;

namespace TestApi.Services.Commands.Category.New;

public class AddNewCategoryCommand : IRequest<int>
{
    public string Title { get; set; }
    public int? ParentId { get; set; }
}