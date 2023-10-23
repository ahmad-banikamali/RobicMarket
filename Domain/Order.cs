using Microsoft.AspNetCore.Identity;

namespace Domain;

public class Order
{
    public int Id { get; set; } 
 
    public Address Address { get; set; }
    public int AddressId { get; set; }

    public Basket Basket { get; set; }
    public int BasketId { get; set; }

    public DateTime DeliveryDateTime  { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
     
}

public enum PaymentMethod
{
    Online,CardByCard
}