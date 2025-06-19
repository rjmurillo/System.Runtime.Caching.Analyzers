using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace System.Runtime.Caching.Analyzers;

/// <summary>
/// Flags usage of System.Runtime.Caching.MemoryCache in .NET Core+ projects. Use Microsoft.Extensions.Caching.Memory instead.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class SystemRuntimeCachingAnalyzer : DiagnosticAnalyzer
{
    /// <summary>
    /// Diagnostic ID for MemoryCache usage in .NET Core+.
    /// </summary>
#pragma warning disable ECS0200 // Roslyn analyzers require const for DiagnosticId
    public const string DiagnosticId = "SRC1000";
#pragma warning restore ECS0200

#pragma warning disable ECS1300 // Roslyn analyzers require inline initialization for DiagnosticDescriptor
    private static readonly DiagnosticDescriptor Rule = new(
        DiagnosticId,
        title: "Avoid System.Runtime.Caching.MemoryCache in .NET Core+",
        messageFormat: "Do not use System.Runtime.Caching.MemoryCache in .NET Core or .NET 5+. Use Microsoft.Extensions.Caching.Memory instead.",
        category: "Compatibility",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "System.Runtime.Caching.MemoryCache is a compatibility bridge for porting from .NET Framework. Prefer Microsoft.Extensions.Caching.Memory in .NET Core+.",
        helpLinkUri: $"https://github.com/rjmurillo/system.runtime.caching.analyzers/blob/{ThisAssembly.GitCommitId}/docs/rules/{DiagnosticId}.md");
#pragma warning restore ECS1300

    /// <inheritdoc />
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    /// <inheritdoc />
    public override void Initialize(AnalysisContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

        context.RegisterCompilationStartAction(static compilationContext =>
        {
            // Only analyze if System.Runtime.Caching is referenced
            INamedTypeSymbol? memoryCacheType = compilationContext.Compilation.GetTypeByMetadataName("System.Runtime.Caching.MemoryCache");
            if (memoryCacheType is null)
            {
                return;
            }

            compilationContext.RegisterOperationAction(
                ctx => AnalyzeObjectCreation(ctx, memoryCacheType),
                OperationKind.ObjectCreation);
            compilationContext.RegisterOperationAction(
                ctx => AnalyzeMemberReference(ctx, memoryCacheType),
                OperationKind.FieldReference,
                OperationKind.PropertyReference,
                OperationKind.MethodReference);
        });
    }

    private static void AnalyzeObjectCreation(OperationAnalysisContext context, INamedTypeSymbol memoryCacheType)
    {
        if (context.Operation is not IObjectCreationOperation creation)
        {
            return;
        }

        if (!SymbolEqualityComparer.Default.Equals(creation.Type, memoryCacheType))
        {
            return;
        }

        // Only analyze if targeting .NET Core+ (not .NET Framework)
        if (context.Compilation.IsTargetingNetFramework() == true)
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(Rule, creation.Syntax.GetLocation()));
    }

    private static void AnalyzeMemberReference(OperationAnalysisContext context, INamedTypeSymbol memoryCacheType)
    {
        IOperation op = context.Operation;
        ITypeSymbol? containingType = op switch
        {
            IFieldReferenceOperation field => field.Field.ContainingType,
            IPropertyReferenceOperation prop => prop.Property.ContainingType,
            IMethodReferenceOperation method => method.Method.ContainingType,
            _ => null,
        };
        if (containingType is null)
        {
            return;
        }

        if (!SymbolEqualityComparer.Default.Equals(containingType, memoryCacheType))
        {
            return;
        }

        // Only analyze if targeting .NET Core+ (not .NET Framework)
        if (context.Compilation.IsTargetingNetFramework() == true)
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(Rule, op.Syntax.GetLocation()));
    }
}
