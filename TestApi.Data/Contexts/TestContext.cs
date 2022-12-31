using Microsoft.EntityFrameworkCore;
using TestApi.Domain.Models;

namespace TestApi.Data.Contexts;

public class TestContext : DbContext
{
    public TestContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "testapi.db");
    }

    private string DbPath { get; }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
