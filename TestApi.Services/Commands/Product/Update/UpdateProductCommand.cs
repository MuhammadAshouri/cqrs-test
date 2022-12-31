using MediatR;
using TestApi.Domain.Models;

namespace TestApi.Services.Commands.Product.Update;

public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public ICollection<ProductProperty> Properties { get; set; }
}