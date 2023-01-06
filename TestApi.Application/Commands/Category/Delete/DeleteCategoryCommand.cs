using MediatR;
using TestApi.Application.Attributes;

namespace TestApi.Application.Commands.Category.Delete;

[MediatorClass]
public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}