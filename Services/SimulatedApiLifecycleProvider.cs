namespace Session2Lab.Services;
using Session2Lab.Interfaces;
using Session2Lab.Models;

public class SimulatedApiLifecycleProvider : ILifecycleProvider
{
    public async Task<LifecycleResults> GetLifecycleAsync(SbomComponent component, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Simulated API call for component: {component.Name}");
        await Task.Delay(1000, cancellationToken); // Simulate network delay
        string status = component.Name.Equals("Legacy.Package", StringComparison.OrdinalIgnoreCase) ? "Deprecated" : "Active";

        return new LifecycleResults(status, "SimulatedApiLifecycleProvider");
    }
}