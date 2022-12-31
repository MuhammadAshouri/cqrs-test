using System.Linq.Expressions;

namespace TestApi.Data.Interfaces;

public interface IRepository<T> : IDisposable where T : class
{
    Task<T?> GetById(int id);
    IQueryable<T> Find(Expression<Func<T, bool>> expression);
    int Count(Expression<Func<T, bool>>? expression = null);
    T Update(T entity);
    T Add(T entity);
    void Remove(T entity);

    Task<T?> First(Expression<Func<T, bool>> condition);
    Task<T?> Single(Expression<Func<T, bool>> condition);

    IQueryable<T> Select();
    IQueryable<T> Select(int page, int pageSize);
    
    IQueryable<T> Where(Expression<Func<T, bool>> condition);
    IQueryable<T> Where(Expression<Func<T, bool>> condition, int page, int pageSize);
}
