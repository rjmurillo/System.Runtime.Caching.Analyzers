using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.Runtime.Caching.Analyzers
{
    /// <summary>
    /// Flags usage of System.Runtime.Caching.MemoryCache in .NET Core+ projects. Use Microsoft.Extensions.Caching.Memory instead.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class SystemRuntimeCachingAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SRC1000";
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId,
            title: "Avoid System.Runtime.Caching.MemoryCache in .NET Core+",
            messageFormat: "Do not use System.Runtime.Caching.MemoryCache in .NET Core or .NET 5+. Use Microsoft.Extensions.Caching.Memory instead.",
            category: "Compatibility",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "System.Runtime.Caching.MemoryCache is a compatibility bridge for porting from .NET Framework. Prefer Microsoft.Extensions.Caching.Memory in .NET Core+.");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            // Failure path: If context is null, throw immediately.
            if (context == null)
                throw new System.ArgumentNullException(nameof(context));
            // TODO: Register actions to analyze symbol and syntax usage.
        }
    }
} 