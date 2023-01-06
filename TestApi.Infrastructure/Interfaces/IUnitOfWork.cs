namespace TestApi.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Complete();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}