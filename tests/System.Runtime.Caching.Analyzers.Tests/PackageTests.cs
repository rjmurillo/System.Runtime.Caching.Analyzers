using System.Reflection;

namespace System.Runtime.Caching.Analyzers.Tests;

public class PackageTests
{
    public static FileInfo Package { get; } = new FileInfo(Assembly.GetExecutingAssembly().Location)
        .Directory!
        .GetFiles("System.Runtime.Caching.Analyzers*.nupkg")
        .OrderByDescending(fileInfo => fileInfo.LastWriteTimeUtc)
        .First();

    [Fact]
    public Task Baseline()
    {
        return VerifyFile(Package).ScrubNuspec();
    }
}
