using Microsoft.AspNetCore.Identity;

namespace Domain;

public class ApplicationUser : IdentityUser
{
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public Basket? Basket { get; set; }
    public int? BasketId { get; set; }
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public Address? DefaultAddress { get; set; }
    public int? DefaultAddressId { get; set; }
    public Order? Order { get; set; }
    public int? OrderId { get; set; }
}