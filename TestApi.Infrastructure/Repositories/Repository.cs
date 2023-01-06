using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestApi.Infrastructure.Interfaces;
using TestApi.Persistence.Contexts;

namespace TestApi.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly TestContext Db;
    private readonly DbSet<T> DbSet;

    public Repository(TestContext context)
    {
        Db = context;
        DbSet = Db.Set<T>();
    }

    public T Update(T entity)
    {
        var da = DbSet.Update(entity);
        return da.Entity;
    }

    public T Add(T entity)
    {
        var da = DbSet.Add(entity);
        return da.Entity;
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> expression) => DbSet.Where(expression);
    public int Count(Expression<Func<T, bool>>? expression = null) => DbSet.Count(expression ?? (_ => true));
    public async Task<T?> GetById(int id) => await DbSet.FindAsync(id);

    public async Task<T?> First(Expression<Func<T, bool>> expression) => await DbSet.FirstOrDefaultAsync(expression);
    public async Task<T?> Single(Expression<Func<T, bool>> expression) => await DbSet.SingleOrDefaultAsync(expression);
    public void Remove(T entity) => DbSet.Remove(entity);

    public IQueryable<T> Select() => DbSet.AsQueryable();
    public IQueryable<T> Select(int page, int pageSize) => DbSet.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize);

    public IQueryable<T> Where(Expression<Func<T, bool>> expression) => DbSet.Where(expression);

    public IQueryable<T> Where(Expression<Func<T, bool>> expression, int page, int pageSize) =>
        DbSet.Where(expression).Skip((page - 1) * pageSize).Take(pageSize);

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }
}