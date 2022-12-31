using TestApi.Data.Contexts;
using TestApi.Data.Interfaces;
using TestApi.Domain.Models;

namespace TestApi.Data.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(TestContext context) : base(context)
    {
    }
}
