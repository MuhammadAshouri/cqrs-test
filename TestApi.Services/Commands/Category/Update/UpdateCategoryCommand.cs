using MediatR;

namespace TestApi.Services.Commands.Category.Update;

public class UpdateCategoryCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? ParentId { get; set; }
}