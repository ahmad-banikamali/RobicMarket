using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages;

public class SignOut : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignOut(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public IActionResult OnGet()
    {
        _signInManager.SignOutAsync();
        return Redirect("/");
    }
}