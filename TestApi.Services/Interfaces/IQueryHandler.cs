namespace TestApi.Services.Interfaces;

public interface IQuery
{
}

public interface IQueryHandler
{
}

public interface IQueryHandler<T> : IQueryHandler where T : IQuery
{
    IEnumerable<IResult> Handle(T query);
}

public interface IQueryDispatcher
{
    IEnumerable<IResult> Send<T>(T query) where T : IQuery;
}