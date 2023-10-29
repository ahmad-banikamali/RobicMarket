namespace Application.OrderService.Command.Dto;

public class CreateOrderRequest
{ 
    public int AddressId { get; set; }
 
    public int BasketId { get; set; }

    public DateTime DeliveryDateTime  { get; set; }

    public int PaymentMethod { get; set; }
}