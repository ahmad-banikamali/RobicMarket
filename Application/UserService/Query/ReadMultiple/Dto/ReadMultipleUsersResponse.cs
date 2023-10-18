using Domain;

namespace Application.UserService.Query.ReadMultiple.Dto;

public class ReadMultipleUsersResponse
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Comment> Comments { get; set; }
}