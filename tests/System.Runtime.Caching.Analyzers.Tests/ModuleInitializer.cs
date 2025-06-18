using System.Runtime.CompilerServices;

namespace System.Runtime.Caching.Analyzers.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyNupkg.Initialize();
    }
}
