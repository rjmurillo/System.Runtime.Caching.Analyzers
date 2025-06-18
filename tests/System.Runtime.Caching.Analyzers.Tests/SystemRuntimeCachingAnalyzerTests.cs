using System.Runtime.Caching.Analyzers.Tests.Helpers;
using Verifier = System.Runtime.Caching.Analyzers.Tests.Helpers.AnalyzerVerifier<System.Runtime.Caching.Analyzers.SystemRuntimeCachingAnalyzer>;

namespace System.Runtime.Caching.Analyzers.Tests;

/// <summary>
/// Unit tests for SystemRuntimeCachingAnalyzer.
/// </summary>
public class SystemRuntimeCachingAnalyzerTests
{
    public static IEnumerable<object[]> MemoryCacheTestData()
    {
        return new object[][]
        {
            ["""var cache = {|SRC1000:new MemoryCache("test")|};"""]
        }.WithSystemRuntimeCachingNamespaces().WithSystemRuntimeCaching();
    }
    
    [Theory]
    [MemberData(nameof(MemoryCacheTestData))]
    public async Task FlagsMemoryCacheUsageInNetCoreProjectAsync(string referenceAssemblyGroup, string @namespace, string code)
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
