using TestApi.Data.Contexts;
using TestApi.Data.Interfaces;
using TestApi.Domain.Exceptions;

namespace TestApi.Data.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestContext Context;
    public UnitOfWork(TestContext context) => Context = context;

    public async Task<bool> Complete()
    {
        try
        {
            return await Context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            throw new SaveChangesException(e);
        }
    }

    public void Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }
}
