using Session2Lab.Interfaces;
using Session2Lab.Models;

namespace Session2Lab.Services;

public class CachedLifecycleProvider : ILifecycleProvider
{
    private readonly Dictionary<string, LifecycleResults> _cache =
        new(StringComparer.OrdinalIgnoreCase);

    public Task<LifecycleResults> GetLifecycleAsync(
        SbomComponent component,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // Check cache first
        if (_cache.TryGetValue(component.Name, out LifecycleResults? cachedResult))
        {
            Console.WriteLine($"Cache hit: {component.Name}");
            return Task.FromResult(cachedResult);
        }

        // Simulate fetching data from another source
        var result = new LifecycleResults(
            "Unknown",
            "CachedLifecycleProvider");

        // Store in cache
        _cache[component.Name] = result;

        Console.WriteLine($"Cache miss: {component.Name}");

        return Task.FromResult(result);
    }
}
