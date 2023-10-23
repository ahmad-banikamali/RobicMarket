namespace Application.AddressService.DefaultAddress.Command.Create.Dto;

public class CreateDefaultAddressRequest
{
    public string ApplicationUserId { get; set; }
    public int DefaultAddressId { get; set; }
}