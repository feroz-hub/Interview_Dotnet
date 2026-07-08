using Session2Lab.Interfaces;
using Session2Lab.Models;
namespace Session2Lab.Services;

public class LocalLifecycleProvider : ILifecycleProvider
{
    private readonly Dictionary<string, string> _statuses = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Newtonsoft.Json"] = "Active",
        ["NUnit"] = "Active",
        ["EntityFramework"] = "Deprecated",
        ["Dapper"] = "Active",
        ["Serilog"] = "Active",
        ["AutoMapper"] = "Active",
        ["FluentValidation"] = "Active",
        ["Moq"] = "Active",
        ["Polly"] = "Active",
        ["Swashbuckle.AspNetCore"] = "Active"
    };
    public async Task<LifecycleResults> GetLifecycleAsync(SbomComponent component, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string status = _statuses.TryGetValue(component.Name, out string? storedStatus) ? storedStatus : "Unknown";
        var result = new LifecycleResults(status, "LocalLifecycleProvider");
        return await Task.FromResult(result);
    }

}