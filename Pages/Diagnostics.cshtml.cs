using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_on_vercel.Pages;

public class DiagnosticsModel : PageModel
{
    public DateTimeOffset UtcNow { get; private set; }
    public string FrameworkDescription { get; private set; } = "";
    public string RuntimeVersion { get; private set; } = "";
    public string OsDescription { get; private set; } = "";
    public string OsArchitecture { get; private set; } = "";
    public string ProcessArchitecture { get; private set; } = "";
    public int ProcessorCount { get; private set; }

    public void OnGet()
    {
        UtcNow = DateTimeOffset.UtcNow;
        FrameworkDescription = RuntimeInformation.FrameworkDescription;
        RuntimeVersion = Environment.Version.ToString();
        OsDescription = RuntimeInformation.OSDescription;
        OsArchitecture = RuntimeInformation.OSArchitecture.ToString();
        ProcessArchitecture = RuntimeInformation.ProcessArchitecture.ToString();
        ProcessorCount = Environment.ProcessorCount;
    }
}
