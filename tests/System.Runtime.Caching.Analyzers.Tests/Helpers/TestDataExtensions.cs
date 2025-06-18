namespace System.Runtime.Caching.Analyzers.Tests.Helpers;

public static class TestDataExtensions
{
    public static IEnumerable<object[]> WithSystemRuntimeCaching(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.Net80WithSystemRuntimeCaching).ToArray();
            yield return item.Prepend(ReferenceAssemblyCatalog.NetFramework462WithSystemRuntimeCaching).ToArray();
        }
    }

    public static IEnumerable<object[]> WithMicrosoftExtensionsCachingMemory(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.Net80WithMicrosoftExtensionsCachingMemory).ToArray();
            yield return item.Prepend(ReferenceAssemblyCatalog.NetFramework462WithMicrosoftExtensionsCachingMemory).ToArray();
        }
    }

    public static IEnumerable<object[]> WithSystemRuntimeCachingNamespaces(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend("using System.Runtime.Caching;").ToArray();
        }
    }
}
