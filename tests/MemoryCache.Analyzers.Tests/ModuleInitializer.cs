using System.Runtime.CompilerServices;

namespace MemoryCache.Analyzers.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyNupkg.Initialize();
    }
}
