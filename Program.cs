using Session2Lab.Models;
using Session2Lab.Interfaces;
using Session2Lab.Services;
namespace Session2Lab;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var component = new SbomComponent("Newtonsoft.Json", "13.0.1", "nuget", "MIT");

        string providerName = args.Length > 0 ? args[0].ToLowerInvariant() : "local";
        ILifecycleProvider lifecycleProvider = providerName switch
        {
            "local" => new LocalLifecycleProvider(),
            "api" => new SimulatedApiLifecycleProvider(),
            "cached" => new CachedLifecycleProvider(),
            _ => throw new ArgumentException($"Unknown Provider:{providerName}"),
        };
        var analysisService = new ComponentAnalysisService(lifecycleProvider);
        await analysisService.AnalyseAsync(component, CancellationToken.None);

    }
}