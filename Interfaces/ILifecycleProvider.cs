using Session2Lab.Models;
namespace Session2Lab.Interfaces;

public interface ILifecycleProvider
{
    Task<LifecycleResults> GetLifecycleAsync(SbomComponent component, CancellationToken cancellationToken);
}