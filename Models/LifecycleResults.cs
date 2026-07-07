namespace Session2Lab.Models;
public class LifecycleResults
{
    public string Status { get; }
    public string Souce { get; }
    public LifecycleResults(string status, string source)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            throw new ArgumentException("Status cannot be null or whitespace.", nameof(status));
        }
        if (string.IsNullOrWhiteSpace(source))
        {
            throw new ArgumentException("Source cannot be null or whitespace.", nameof(source));
        }
        Status = status.Trim();
        Souce = source.Trim();
    }
}