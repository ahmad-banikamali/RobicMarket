namespace Application.Utils.Identity.Dto;

public class SigninDto
{
    public string EmailOrPhoneNumberOrUserName { get; set; }
    public string Password { get; set; } 
    
    public string ReturnUrl { get; set; } = "/";
}