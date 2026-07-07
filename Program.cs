using Session2Lab.Models;
namespace Session2Lab;

internal static class Program
{
    private static void Main(string[] args)
    {
        var component = new SbomComponent("Newtonsoft.Json", "13.0.1", "nuget", "MIT");

        Console.WriteLine("Initial Component");
        Console.WriteLine("---------------");
        component.PrintSummary();

        Console.WriteLine();

        component.UpdateVersion("13.0.2");
        component.MakeVulnerable("CVE-2021-12345", "High");

        Console.WriteLine("After Analysis");
        Console.WriteLine("--------------");
        component.PrintSummary();

        Console.WriteLine();

        component.ClearVulnerability();
        Console.WriteLine("After vulnerability cleared");
        Console.WriteLine("---------------");
        component.PrintSummary();
    }
}