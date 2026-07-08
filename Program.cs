using Session2Lab.Models;
using Session2Lab.Interfaces;
using Session2Lab.Services;
namespace Session2Lab;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var component = new SbomComponent("Newtonsoft.Json", "13.0.1", "nuget", "MIT");

        ILifecycleProvider lifecycleProvider = new SimulatedApiLifecycleProvider();
        var analysisService = new ComponentAnalysisService(lifecycleProvider);
        await analysisService.AnalyseAsync(component, CancellationToken.None);

    }
}