using System.Reflection;

namespace AdventOfCode.Tests.Helpers;

public static class FileReader
{
    public static string ReadResource(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourcePath = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith(name));
        
        using var stream = assembly.GetManifestResourceStream(resourcePath);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}