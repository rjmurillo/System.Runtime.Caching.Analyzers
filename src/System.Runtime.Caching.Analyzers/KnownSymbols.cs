using Analyzer.Utilities;
using Microsoft.CodeAnalysis;

namespace System.Runtime.Caching.Analyzers;

/// <summary>
/// <p>Main entrypoint to access well-known symbols for the analyzer.
/// This class handles caching to prevent multiple lookups for the same symbol.</p>
///
/// <p>It returns a type derived from <see cref="ISymbol"/> in all cases. Use the
/// <seealso cref="ISymbol.ToDisplayString(SymbolDisplayFormat?)"/> when necessary
/// for comparisons with <seealso cref="SyntaxNode"/>s.</p>
/// </summary>
internal class KnownSymbols(WellKnownTypeProvider typeProvider)
{
    public KnownSymbols(Compilation compilation)
        : this(WellKnownTypeProvider.GetOrCreate(compilation))
    {
    }

    public INamedTypeSymbol? SystemRuntimeCachingMemoryCache => typeProvider.GetOrCreateTypeByMetadataName("System.Runtime.Caching.MemoryCache");
}
