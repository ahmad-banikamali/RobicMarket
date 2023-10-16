using Application.Utils.Identity.Dto;
using AutoMapper;
using Common.Extension;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages;

public class SignUp : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager; 

    [BindProperty] public SignUpDto SignUpDto { get; set; }

    public SignUp(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
     )
    {
        _userManager = userManager;
        _signInManager = signInManager; 
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        var isEmail = SignUpDto.EmailOrPhoneNumber.IsValidEmail();
        var isPhoneNumber = SignUpDto.EmailOrPhoneNumber.IsValidPhoneNumber();
        if (!isPhoneNumber && !isEmail)
            return Page();

        var result = _userManager.CreateAsync(new ApplicationUser()
        {
            UserName = SignUpDto.UserName,
            PhoneNumber = isPhoneNumber ? SignUpDto.EmailOrPhoneNumber : null,
            Email = isEmail ? SignUpDto.EmailOrPhoneNumber : null
        }, SignUpDto.Password).Result;

 
        if (result.Succeeded)
            return Redirect(SignUpDto.ReturnUrl);

        return Page();
    }
}