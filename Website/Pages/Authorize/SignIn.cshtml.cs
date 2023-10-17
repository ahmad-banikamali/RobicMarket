using Application.Utils.Identity.Dto;
using Common.Extension;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages;

public class SignIn : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    [BindProperty] public SigninDto SigninDto { get; set; } = new SigninDto();

    public SignIn(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        var userIdentity = SigninDto.EmailOrPhoneNumberOrUserName;
        var isEmail = userIdentity.IsValidEmail();
        var isPhoneNumber = userIdentity.IsValidPhoneNumber();
        var isUserName = !isEmail && !isPhoneNumber;
        ApplicationUser? user;
        if (isEmail)
        {
            user = _userManager.FindByEmailAsync(userIdentity).Result;
        }
        else if (isUserName)
        {
            user = _userManager.FindByNameAsync(userIdentity).Result;
        }
        else
        {
            user = null;
        }
        // find user by phoneNumber:
        // https://stackoverflow.com/a/66668546

        if (user == null) return Page();
    
        var passwordSignIn = _signInManager.PasswordSignInAsync(user, SigninDto.Password, true, false).Result;
        if (passwordSignIn.Succeeded)
            return Redirect(SigninDto.ReturnUrl);
        
        return Page();
    }
}