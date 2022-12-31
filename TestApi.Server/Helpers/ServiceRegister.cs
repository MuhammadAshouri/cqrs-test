using MediatR;
using TestApi.Data.Contexts;
using TestApi.Data.Interfaces;
using TestApi.Data.Repositories;
using TestApi.Data.Uow;
using TestApi.Services.Commands.Category.Delete;
using TestApi.Services.Commands.Category.New;
using TestApi.Services.Commands.Category.Update;
using TestApi.Services.Commands.Product.Delete;
using TestApi.Services.Commands.Product.New;
using TestApi.Services.Commands.Product.Update;
using TestApi.Services.Interfaces;
using TestApi.Services.Queries.Category;
using TestApi.Services.Queries.Product;
using TestApi.Services.Services;

namespace TestApi.Server.Helpers;

public static class ServiceRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<TestContext>();
        services.AddSwaggerGen();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IReporterService, ReporterService>();

        services.AddMediatR(typeof(AddNewProductCommand), typeof(AddNewCategoryCommand), typeof(UpdateProductCommand), typeof(UpdateCategoryCommand),
            typeof(DeleteProductCommand), typeof(DeleteCategoryCommand), typeof(GetProductsQuery), typeof(GetProductsFromCategoryQuery),
            typeof(GetCategoriesQuery));
    }
}
