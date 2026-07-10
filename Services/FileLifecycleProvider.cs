using Session2Lab.Models;

namespace Session2Lab.Services;

public sealed class FileLifecycleProvider
    : LifecycleProviderBase
{
    private readonly string _filePath;

    public FileLifecycleProvider(string filePath)
        : base("Local text file")
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException(
                "File path cannot be empty.",
                nameof(filePath));
        }

        _filePath = filePath;
    }

    protected override async Task<string> FetchStatusAsync(
        SbomComponent component,
        CancellationToken cancellationToken)
    {
        if (!File.Exists(_filePath))
        {
            return "Unknown";
        }

        string[] lines = await File.ReadAllLinesAsync(
            _filePath,
            cancellationToken);

        foreach (string line in lines)
        {
            string[] parts = line.Split(
                '=',
                count: 2,
                StringSplitOptions.TrimEntries);

            if (parts.Length != 2)
            {
                continue;
            }

            if (parts[0].Equals(
                component.Name,
                StringComparison.OrdinalIgnoreCase))
            {
                return parts[1];
            }
        }

        return "Unknown";
    }
}