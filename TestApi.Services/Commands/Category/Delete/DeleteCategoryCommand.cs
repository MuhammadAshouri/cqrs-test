using MediatR;

namespace TestApi.Services.Commands.Category.Delete;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}