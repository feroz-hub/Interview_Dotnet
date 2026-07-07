namespace Session2Lab.Models;

public class SbomComponent
{

    private static readonly HashSet<string> ValidEcosystems = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "NuGet",
        "NPM",
        "Maven",
        "PyPI"
    };
    private static readonly HashSet<string> ValidSeverities = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "Critical",
        "High",
        "Medium",
        "Low"
    };
    public string Name { get; private set; }
    public string? Severity { get; private set; }
    public string Version { get; private set; }
    public string EcoSystem { get; private set; }
    public string License { get; private set; }
    public bool IsVulnerable { get; private set; }
    public string? VulnerabilityId { get; private set; }
    public string DisplayName => $"{Name} ({Version})";

    public SbomComponent(string name, string version, string ecoSystem, string license)
    {
        Name = ValidateRequiredValue(name, nameof(Name));
        Version = ValidateRequiredValue(version, nameof(Version));
        EcoSystem = ValidateEcosystem(ecoSystem);
        License = ValidateRequiredValue(license, nameof(License));

    }
    public void UpdateVersion(string newVersion)
    {
        Version = ValidateRequiredValue(newVersion, nameof(Version));
    }

    public void MakeVulnerable(string vulnerabilityId, string severity)
    {

        VulnerabilityId = ValidateRequiredValue(vulnerabilityId, nameof(VulnerabilityId));
        Severity = ValidateSeverity(severity);
        IsVulnerable = true;
    }

    public void ClearVulnerability()
    {
        VulnerabilityId = null;
        IsVulnerable = false;
    }



    public void UpdateLicense(string newLicense)
    {
        License = ValidateRequiredValue(newLicense, nameof(License));
    }

    public void PrintSummary()
    {
        Console.WriteLine($"Component: {Name}");
        Console.WriteLine($"Version: {Version}");
        Console.WriteLine($"EcoSystem: {EcoSystem}");
        Console.WriteLine($"License: {License}");
        Console.WriteLine($"Vulnerable: {IsVulnerable}");

        if (IsVulnerable)
        {
            Console.WriteLine($"Vulnerability ID: {VulnerabilityId}");
        }

    }

    public static string ValidateRequiredValue(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"The {propertyName} property is required and cannot be null or empty.");
        }
        return value.Trim();
    }

    public static string ValidateEcosystem(string ecosystem)
    {
        string normalizedEcosystem = ValidateRequiredValue(ecosystem, nameof(EcoSystem));

        if (!ValidEcosystems.Contains(normalizedEcosystem))
        {
            throw new ArgumentException($"The {nameof(EcoSystem)} property must be one of the following: {string.Join(", ", ValidEcosystems)}.");
        }
        return ValidEcosystems.First(value => value.Equals(normalizedEcosystem, StringComparison.OrdinalIgnoreCase));
    }

    public static string ValidateSeverity(string severity)
    {
        string normalizedSeverity = ValidateRequiredValue(severity, nameof(Severity));

        if (!ValidSeverities.Contains(normalizedSeverity))
        {
            throw new ArgumentException($"The {nameof(Severity)} property must be one of the following: {string.Join(", ", ValidSeverities)}.");
        }
        return ValidSeverities.First(value => value.Equals(normalizedSeverity, StringComparison.OrdinalIgnoreCase));
    }
}