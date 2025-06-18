namespace System.Runtime.Caching.Analyzers.Tests.Helpers;

/// <summary>
/// Provides extension methods for composing and enriching test data sets with reference assembly and namespace information
/// required for analyzer and code fix tests targeting different caching APIs and .NET versions.
/// </summary>
/// <remarks>
/// These helpers allow test authors to fluently add reference assembly group identifiers and required namespace imports to
/// <c>IEnumerable&lt;object[]&gt;</c> test data. This enables parameterized tests to cover multiple target frameworks and caching implementations
/// without duplicating boilerplate setup code.
/// </remarks>
public static class TestDataExtensions
{
    /// <summary>
    /// Adds the .NET 8.0 System.Runtime.Caching reference group identifier to each test data row.
    /// Use for tests that require System.Runtime.Caching APIs on .NET 8.
    /// </summary>
    public static IEnumerable<object[]> WithNet80SystemRuntimeCaching(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.Net80WithSystemRuntimeCaching).ToArray();
        }
    }

    /// <summary>
    /// Adds the .NET Framework 4.6.2 System.Runtime.Caching reference group identifier to each test data row.
    /// Use for tests that require System.Runtime.Caching APIs on .NET Framework 4.6.2.
    /// </summary>
    public static IEnumerable<object[]> WithFramework462SystemRuntimeCaching(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.NetFramework462WithSystemRuntimeCaching).ToArray();
        }
    }

    /// <summary>
    /// Adds a <c>using System.Runtime.Caching;</c> namespace import to each test data row.
    /// Use for tests that require the System.Runtime.Caching namespace in the source code.
    /// </summary>
    public static IEnumerable<object[]> WithSystemRuntimeCachingNamespaces(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend("using System.Runtime.Caching;").ToArray();
        }
    }

    /// <summary>
    /// Adds a <c>using Microsoft.Extensions.Caching.Memory;</c> namespace import to each test data row.
    /// Use for tests that require the Microsoft.Extensions.Caching.Memory namespace in the source code.
    /// </summary>
    public static IEnumerable<object[]> WithMicrosoftExtensionsCachingMemoryNamespaces(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend("using Microsoft.Extensions.Caching.Memory;").ToArray();
        }
    }

    /// <summary>
    /// Adds the .NET 8.0 Microsoft.Extensions.Caching.Memory reference group identifier to each test data row.
    /// Use for tests that require Microsoft.Extensions.Caching.Memory APIs on .NET 8.
    /// </summary>
    public static IEnumerable<object[]> WithNet80MicrosoftExtensionsCachingMemory(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.Net80WithMicrosoftExtensionsCachingMemory).ToArray();
        }
    }

    /// <summary>
    /// Adds the .NET Framework 4.6.2 Microsoft.Extensions.Caching.Memory reference group identifier to each test data row.
    /// Use for tests that require Microsoft.Extensions.Caching.Memory APIs on .NET Framework 4.6.2.
    /// </summary>
    public static IEnumerable<object[]> WithFramework462MicrosoftExtensionsCachingMemory(this IEnumerable<object[]> data)
    {
        foreach (object[] item in data)
        {
            yield return item.Prepend(ReferenceAssemblyCatalog.NetFramework462WithMicrosoftExtensionsCachingMemory).ToArray();
        }
    }
}
