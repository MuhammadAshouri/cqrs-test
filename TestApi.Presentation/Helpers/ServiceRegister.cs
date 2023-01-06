using MediatR;
using TestApi.Application.Interfaces;
using TestApi.Application.Services;
using TestApi.Infrastructure.Interfaces;
using TestApi.Infrastructure.Uow;
using TestApi.Persistence.Contexts;

namespace TestApi.Presentation.Helpers;

public static class ServiceRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<TestContext>();
        services.AddSwaggerGen();

        services.AddSingleton<IReporterService, ReporterService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // services.AddMediatR(typeof(AddNewProductCommand), typeof(AddNewCategoryCommand), typeof(UpdateProductCommand), typeof(UpdateCategoryCommand),
        //     typeof(DeleteProductCommand), typeof(DeleteCategoryCommand), typeof(GetProductsQuery), typeof(GetProductsFromCategoryQuery),
        //     typeof(GetCategoriesQuery));
        services.AddMediatR(MediatorConfig.ConfigClasses());
    }
}