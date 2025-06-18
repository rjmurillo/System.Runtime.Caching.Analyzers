namespace System.Runtime.Caching.Analyzers.Tests.Helpers;

public static class TestDataExtensions
{
    /// <summary>
    /// Add the .NET 8.0 System.Runtime.Caching reference to the test data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> WithNet80SystemRuntimeCaching(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.Net80WithSystemRuntimeCaching).ToArray();
        }
    }

    /// <summary>
    /// Add the .NET Framework 4.6.2 System.Runtime.Caching reference to the test data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> WithFramework462SystemRuntimeCaching(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.NetFramework462WithSystemRuntimeCaching).ToArray();
        }
    }

    /// <summary>
    /// Add the System.Runtime.Caching namespace to the test data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> WithSystemRuntimeCachingNamespaces(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend("using System.Runtime.Caching;").ToArray();
        }
    }

    /// <summary>
    /// Add the Microsoft.Extensions.Caching.Memory namespace to the test data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> WithMicrosoftExtensionsCachingMemoryNamespaces(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend("using Microsoft.Extensions.Caching.Memory;").ToArray();
        }
    }

    /// <summary>
    /// Add the .NET 8.0 Microsoft.Extensions.Caching.Memory reference to the test data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> WithNet80MicrosoftExtensionsCachingMemory(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.Net80WithMicrosoftExtensionsCachingMemory).ToArray();
        }
    }

    /// <summary>
    /// Add the .NET Framework 4.6.2 Microsoft.Extensions.Caching.Memory reference to the test data.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> WithFramework462MicrosoftExtensionsCachingMemory(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.NetFramework462WithMicrosoftExtensionsCachingMemory).ToArray();
        }
    }
}
