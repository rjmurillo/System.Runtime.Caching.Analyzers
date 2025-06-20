using System.Reflection;

namespace MemoryCache.Analyzers.Tests;

public class PackageTests
{
    public static FileInfo Package { get; } = new FileInfo(Assembly.GetExecutingAssembly().Location)
        .Directory!
        .GetFiles("MemoryCache.Analyzers*.nupkg")
        .OrderByDescending(fileInfo => fileInfo.LastWriteTimeUtc)
        .First();

    [Fact]
    public Task Baseline()
    {
        return VerifyFile(Package).ScrubNuspec();
    }
}
