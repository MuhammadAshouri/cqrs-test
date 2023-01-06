using TestApi.Infrastructure.Interfaces;
using TestApi.Infrastructure.Repositories;
using TestApi.Persistence.Contexts;

namespace TestApi.Infrastructure.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestContext Context;
    private readonly IDictionary<Type, object> Repositories;

    public UnitOfWork(TestContext context)
    {
        Context = context;
        Repositories = new Dictionary<Type, object>();
    }

    public async Task<bool> Complete() => await Context.SaveChangesAsync() > 0;

    public void Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var entityType = typeof(TEntity);
        if (Repositories.TryGetValue(entityType, out var value)) return value as IRepository<TEntity> ?? throw new("Repository doesnt exists");
        IRepository<TEntity> repository = new Repository<TEntity>(Context);
        Repositories.Add(entityType, repository);
        return repository;
    }
}