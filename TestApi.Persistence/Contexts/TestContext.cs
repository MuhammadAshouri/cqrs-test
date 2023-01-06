using System.Reflection;
using System.Runtime.Loader;
using Microsoft.EntityFrameworkCore;
using TestApi.Domain.Attributes;

namespace TestApi.Persistence.Contexts;

public class TestContext : DbContext
{
    public TestContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "testapi.db");
    }

    private string DbPath { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        MigrationAndUpdateDatabaseEntities(modelBuilder);

    private static void MigrationAndUpdateDatabaseEntities(ModelBuilder modelBuilder)
    {
        var asmPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestApi.Domain.dll";
        var modelInAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(asmPath);
        var entityMethod = typeof(ModelBuilder).GetMethod("Entity", Array.Empty<Type>());
        if (entityMethod == null) return;

        foreach (var type in modelInAssembly.ExportedTypes)
        {
            var typeFind = type.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == nameof(EntityTypeAttribute));
            if (typeFind != null)
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, Array.Empty<object>());
        }
    }
}