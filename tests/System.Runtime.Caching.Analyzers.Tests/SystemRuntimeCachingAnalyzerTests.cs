using Verifier = System.Runtime.Caching.Analyzers.Tests.Helpers.AnalyzerVerifier<System.Runtime.Caching.Analyzers.SystemRuntimeCachingAnalyzer>;

namespace System.Runtime.Caching.Analyzers.Tests;

/// <summary>
/// Unit tests for SystemRuntimeCachingAnalyzer.
/// </summary>
public class SystemRuntimeCachingAnalyzerTests
{
    public static IEnumerable<object[]> MemoryCacheTestData()
    {
        IEnumerable<object[]> net80SystemRuntimeCaching = new object[][]
        {
            ["""var cache = {|SRC1000:new MemoryCache("test")|};"""],
        }.WithSystemRuntimeCachingNamespaces().WithNet80SystemRuntimeCaching();

        IEnumerable<object[]> net80MicrosoftExtensionsCachingMemory = new object[][]
        {
            ["""var cache = new MemoryCache(new MemoryCacheOptions());"""],
        }.WithMicrosoftExtensionsCachingMemoryNamespaces().WithNet80MicrosoftExtensionsCachingMemory();

        IEnumerable<object[]> framework462SystemRuntimeCaching = new object[][]
        {
            ["""var cache = new MemoryCache("test");"""],
        }.WithSystemRuntimeCachingNamespaces().WithFramework462SystemRuntimeCaching();

        IEnumerable<object[]> framework462MicrosoftExtensionsCachingMemory = new object[][]
        {
            ["""var cache = new MemoryCache(new MemoryCacheOptions());"""],
        }.WithMicrosoftExtensionsCachingMemoryNamespaces().WithFramework462MicrosoftExtensionsCachingMemory();

        return net80SystemRuntimeCaching
            .Union(net80MicrosoftExtensionsCachingMemory)
            .Union(framework462SystemRuntimeCaching)
            .Union(framework462MicrosoftExtensionsCachingMemory);
    }

    [Theory]
    [MemberData(nameof(MemoryCacheTestData))]
    public async Task FlagsMemoryCacheUsageInNetCoreProjec(string referenceAssemblyGroup, string @namespace, string code)
    {
        await Verifier.VerifyAnalyzerAsync(
            $$"""
              {{@namespace}}

              class C
              {
                  void M()
                  {
                      {{code}}
                  }

              }
              """,
            referenceAssemblyGroup);
    }
}
