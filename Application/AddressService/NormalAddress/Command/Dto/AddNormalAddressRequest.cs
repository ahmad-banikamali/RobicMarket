namespace Application.AddressService.NormalAddress.Command.Dto;

public class AddNormalAddressRequest
{
    public string UserId { get; set; }
    public int ProvinceId { get; set; }
    public int CityId { get; set; } = 2;
    public string FullAddress { get; set; }
    public string PostalCode { get; set; }
    public string TransfereeName { get; set; }
    public string TransfereePhone { get; set; }
}