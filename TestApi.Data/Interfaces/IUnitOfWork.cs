namespace TestApi.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Complete();
}