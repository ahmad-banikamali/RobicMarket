namespace Application.Utils.Identity.Dto;

public class SignUpDto
{
    public string UserName { get; set; }
    public string EmailOrPhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string ReturnUrl { get; set; } = "/";
}