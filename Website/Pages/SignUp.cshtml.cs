using Application.Utils;
using Application.Utils.Identity.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages;

public class SignUp : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    [BindProperty] public SignUpDto SignUpDto { get; set; }

    public SignUp(UserManager<IdentityUser> userManager,IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        IdentityUser identityUser = _mapper.Map<IdentityUser>(SignUpDto);
        _userManager.CreateAsync(identityUser,SignUpDto.Password);
    }
}