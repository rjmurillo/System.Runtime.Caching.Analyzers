using Microsoft.CodeAnalysis;

namespace System.Runtime.Caching.Analyzers;

/// <summary>
/// Provides extension methods for working with <see cref="ITypeSymbol"/> instances in Roslyn analyzers.
/// </summary>
internal static class ITypeSymbolExtensions
{
    /// <summary>
    /// Determines whether the specified <paramref name="type"/> is the same as, or derives from, the given <paramref name="baseType"/>.
    /// </summary>
    /// <param name="type">The type symbol to check. May be <see langword="null"/>.</param>
    /// <param name="baseType">The base type symbol to compare against.</param>
    /// <returns><see langword="true" /> if <paramref name="type"/> is the same as or derives from <paramref name="baseType"/>; otherwise, <see langword="false" />.</returns>
    internal static bool IsOrDerivedFrom(ITypeSymbol? type, INamedTypeSymbol baseType)
    {
        while (type != null)
        {
            if (SymbolEqualityComparer.Default.Equals(type, baseType))
            {
                return true;
            }

            type = type.BaseType;
        }

        return false;
    }
}
