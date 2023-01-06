using System.Reflection;
using System.Runtime.Loader;
using TestApi.Application.Attributes;

namespace TestApi.Presentation.Helpers;

public class MediatorConfig
{
    public static Type[] ConfigClasses()
    {
        var asmPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestApi.Application.dll";
        var modelInAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(asmPath);
        return (from type in modelInAssembly.ExportedTypes
            let typeFind = type.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == nameof(MediatorClassAttribute))
            where typeFind != null
            select type).ToArray();
    }
}