using Analyzer.Utilities;
using Microsoft.CodeAnalysis;

namespace System.Runtime.Caching.Analyzers;

/// <summary>
/// Main entrypoint to access well-known symbols for the analyzer.
/// This class handles caching to prevent multiple lookups for the same symbol.
///
/// It returns a type derived from <see cref="ISymbol"/> in all cases. Use the
/// <seealso cref="ISymbol.ToDisplayString(SymbolDisplayFormat?)"/> when necessary
/// for comparisons with <seealso cref="SyntaxNode"/>s.
/// </summary>
internal class KnownSymbols(WellKnownTypeProvider typeProvider)
{
    public KnownSymbols(Compilation compilation)
        : this(WellKnownTypeProvider.GetOrCreate(compilation))
    {
    }

    protected WellKnownTypeProvider TypeProvider { get; } = typeProvider;

    public INamedTypeSymbol? SystemRuntimeCachingMemoryCache => TypeProvider.GetOrCreateTypeByMetadataName("System.Runtime.Caching.MemoryCache");
}
