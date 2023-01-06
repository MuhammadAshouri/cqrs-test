using MediatR;
using TestApi.Application.Attributes;
using TestApi.Domain.Models;

namespace TestApi.Application.Commands.Product.Update;

[MediatorClass]
public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public ICollection<ProductProperty> Properties { get; set; }
}