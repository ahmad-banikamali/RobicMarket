using Microsoft.AspNetCore.Identity;

namespace Domain;

public class ApplicationUser : IdentityUser
{
    public List<Comment> Comments { get; set; } = new List<Comment>();
}