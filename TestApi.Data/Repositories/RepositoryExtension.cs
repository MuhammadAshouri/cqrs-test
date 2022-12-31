namespace TestApi.Data.Repositories;

public static class RepositoryExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> list, int page, int pageSize) =>
        list.Skip((page - 1) * pageSize).Take(pageSize);
}
