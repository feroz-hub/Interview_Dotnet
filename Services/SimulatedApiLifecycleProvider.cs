namespace Session2Lab.Services;

using Session2Lab.Interfaces;
using Session2Lab.Models;

public class SimulatedApiLifecycleProvider : LifecycleProviderBase
{
    public SimulatedApiLifecycleProvider() : base("SimulatedApiLifecycleProvider")
    {
    }

    protected override async Task<string> FetchStatusAsync(SbomComponent component, CancellationToken cancellationToken)
    {
        Console.WriteLine("Sending request to Simulated API for component: " + component.Name);
        await Task.Delay(1000, cancellationToken); // Simulate network delay
        if (component.Name.Equals("Legacy.Package", StringComparison.OrdinalIgnoreCase))
        {
            return "EOL";
        }
        else
        {
            return "SUPPORTED";
        }
    }

    protected override string NormalizeStatus(string rawStatus)
    {
        return rawStatus.Trim().ToUpperInvariant() switch
        {
            "EOL" => "End of Life",
            "SUPPORTED" => "End of Support",
            _ => base.NormalizeStatus(rawStatus)
        };
    }
}