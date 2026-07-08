using Session2Lab.Models;
using Session2Lab.Interfaces;
namespace Session2Lab.Services;

public class ComponentAnalysisService
{
    private readonly ILifecycleProvider _lifecycleProvider;

    public ComponentAnalysisService(ILifecycleProvider lifecycleProvider)
    {
        _lifecycleProvider = lifecycleProvider ?? throw new ArgumentNullException(nameof(lifecycleProvider));
    }

    public async Task AnalyseAsync(SbomComponent component, CancellationToken cancellationToken)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        var lifecycleResults = await _lifecycleProvider.GetLifecycleAsync(component, cancellationToken);
        Console.WriteLine($"Component: {component.Name}, Version: {component.Version}, Status: {lifecycleResults.Status}, Source: {lifecycleResults.Souce}");
    }
}
