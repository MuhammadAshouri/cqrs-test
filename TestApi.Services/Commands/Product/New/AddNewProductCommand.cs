using MediatR;
using TestApi.Domain.Models;

namespace TestApi.Services.Commands.Product.New;

public class AddNewProductCommand : IRequest<int>
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public ICollection<ProductProperty> Properties { get; set; }
}