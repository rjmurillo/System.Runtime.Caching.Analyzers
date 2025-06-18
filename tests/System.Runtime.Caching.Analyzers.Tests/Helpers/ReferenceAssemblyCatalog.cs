using Microsoft.CodeAnalysis.Testing;

namespace System.Runtime.Caching.Analyzers.Tests.Helpers;

/// <summary>
/// The testing framework does heavy work to resolve references for set of <see cref="ReferenceAssemblies"/>, including potentially
/// running the NuGet client to download packages. This class caches the ReferenceAssemblies class (which is thread-safe), so that
/// package resolution only happens once for a given configuration.
/// </summary>
/// <remarks>
/// It would be more straightforward to pass around ReferenceAssemblies instances directly, but using non-primitive types causes
/// Visual Studio's Test Explorer to collapse all test cases down to a single entry, which makes it harder to see which test cases
/// are failing or debug a single test case.
/// </remarks>
public static class ReferenceAssemblyCatalog
{
    public static string Net80WithSystemRuntimeCaching => nameof(Net80WithSystemRuntimeCaching);

    public static string NetFramework462WithSystemRuntimeCaching => nameof(NetFramework462WithSystemRuntimeCaching);

    public static string Net80WithMicrosoftExtensionsCachingMemory => nameof(Net80WithMicrosoftExtensionsCachingMemory);

    public static string NetFramework462WithMicrosoftExtensionsCachingMemory => nameof(NetFramework462WithMicrosoftExtensionsCachingMemory);

    /// <summary>
    /// Gets a catalog of reference assemblies grouped by their respective identifiers.
    /// </summary>
    /// <remarks>
    /// The catalog provides a mapping between string identifiers and corresponding
    /// <see cref="Microsoft.CodeAnalysis.Testing.ReferenceAssemblies"/> instances.
    /// It is used to configure the reference assemblies for analyzer tests.
    /// </remarks>
    /// <value>
    /// A read-only dictionary where the keys are string identifiers and the values are
    /// <see cref="Microsoft.CodeAnalysis.Testing.ReferenceAssemblies"/> instances.
    /// </value>
    public static IReadOnlyDictionary<string, ReferenceAssemblies> Catalog { get; } =
        new Dictionary<string, ReferenceAssemblies>(StringComparer.Ordinal)
        {
            {
                nameof(Net80WithSystemRuntimeCaching),
                ReferenceAssemblies.Net.Net80.AddPackages([new PackageIdentity("System.Runtime.Caching", "8.0.0")])
            },
            {
                nameof(NetFramework462WithSystemRuntimeCaching),
                ReferenceAssemblies.NetFramework.Net462.Default.AddPackages([new PackageIdentity("System.Runtime.Caching", "8.0.0")])
            },
            {
                nameof(Net80WithMicrosoftExtensionsCachingMemory),
                ReferenceAssemblies.Net.Net80.AddPackages([new PackageIdentity("Microsoft.Extensions.Caching.Memory", "8.0.0")])
            },
            {
                nameof(NetFramework462WithMicrosoftExtensionsCachingMemory),
                ReferenceAssemblies.NetFramework.Net462.Default.AddPackages([new PackageIdentity("Microsoft.Extensions.Caching.Memory", "8.0.0")])
            },
        };
}
