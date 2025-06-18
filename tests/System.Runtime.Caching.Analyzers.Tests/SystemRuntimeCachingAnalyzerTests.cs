using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Xunit;

namespace System.Runtime.Caching.Analyzers.Tests
{
    /// <summary>
    /// Unit tests for SystemRuntimeCachingAnalyzer.
    /// </summary>
    public class SystemRuntimeCachingAnalyzerTests
    {
        private static DiagnosticResult ExpectedDiagnostic(int line, int column) =>
            new DiagnosticResult(SystemRuntimeCachingAnalyzer.DiagnosticId, DiagnosticSeverity.Warning)
                .WithSpan(line, column, line, column + 11); // "MemoryCache" length

        [Fact]
        public async Task FlagsMemoryCacheUsageInNetCoreProject()
        {
            var testCode = @"using System.Runtime.Caching;

class C
{
    void M()
    {
        var cache = new MemoryCache(\"test\");
    }
}";
            var test = new CSharpAnalyzerTest<SystemRuntimeCachingAnalyzer, XUnitVerifier>
            {
                TestCode = testCode,
                ReferenceAssemblies = ReferenceAssemblies.Net.Net50
            };
            test.ExpectedDiagnostics.Add(ExpectedDiagnostic(7, 22));
            await test.RunAsync();
        }

        [Fact]
        public async Task DoesNotFlagMemoryCacheUsageInNetFramework()
        {
            var testCode = @"using System.Runtime.Caching;

class C
{
    void M()
    {
        var cache = new MemoryCache(\"test\");
    }
}";
            var test = new CSharpAnalyzerTest<SystemRuntimeCachingAnalyzer, XUnitVerifier>
            {
                TestCode = testCode,
                ReferenceAssemblies = ReferenceAssemblies.NetFramework.Net48
            };
            // No diagnostics expected
            await test.RunAsync();
        }
    }
} 