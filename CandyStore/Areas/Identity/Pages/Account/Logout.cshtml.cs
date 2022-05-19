using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandyStore.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class LogoutModel : PageModel
{
    readonly ILogger<LogoutModel> _logger;
    readonly SignInManager<IdentityUser> _signInManager;

    public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPost(string? returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
            return LocalRedirect(returnUrl);
        return RedirectToPage();
    }
}