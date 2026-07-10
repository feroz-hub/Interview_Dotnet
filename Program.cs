using Session2Lab.Interfaces;
using Session2Lab.Models;
using Session2Lab.Services;

namespace Session2Lab;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var component = new SbomComponent(
            "Newtonsoft.Json",
            "13.0.3",
            "NuGet",
            "MIT");

        ILifecycleProvider[] providers =
        [
            new LocalLifecycleProvider(),
            new SimulatedApiLifecycleProvider(),
            new FileLifecycleProvider("lifecycle-data.txt")
        ];

        foreach (ILifecycleProvider provider in providers)
        {
            var analysisService =
                new ComponentAnalysisService(provider);

            await analysisService.AnalyseAsync(
                component,
                CancellationToken.None);

            Console.WriteLine();
        }
    }
}