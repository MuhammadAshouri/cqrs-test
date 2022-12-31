using TestApi.Data.Contexts;
using TestApi.Data.Interfaces;
using TestApi.Domain.Models;

namespace TestApi.Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(TestContext context) : base(context)
    {
    }
}
