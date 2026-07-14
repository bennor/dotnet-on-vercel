using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_on_vercel.Pages;

public class HowItWorksModel : PageModel
{
    private readonly ILogger<HowItWorksModel> _logger;

    public HowItWorksModel(ILogger<HowItWorksModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
