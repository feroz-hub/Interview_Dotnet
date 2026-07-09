using Session2Lab.Interfaces;
using Session2Lab.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session2Lab.Services
{
    public abstract class LifecycleProviderBase : ILifecycleProvider
    {
        public string ProviderName { get; }

        protected LifecycleProviderBase(string providerName)
        {
            ProviderName = providerName ?? throw new ArgumentNullException(nameof(providerName));
        }
        public async Task<LifecycleResults> GetLifecycleAsync(SbomComponent component, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(component);

            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"[{ProviderName}] Looking up lifecycle for component: {component.DisplayName}");

            string rawStatus = await FetchStatusAsync(component, cancellationToken);

            string normalizedStatus = NormalizeStatus(rawStatus);

            return new LifecycleResults(normalizedStatus, ProviderName);

        }

        protected virtual string NormalizeStatus(string rawStatus)
        {
            if (string.IsNullOrEmpty(rawStatus))
            {
                return "Unknown";

            }
            return rawStatus.Trim();
        }

        protected abstract Task<string> FetchStatusAsync(SbomComponent component, CancellationToken cancellationToken);
        
        
    }
}
