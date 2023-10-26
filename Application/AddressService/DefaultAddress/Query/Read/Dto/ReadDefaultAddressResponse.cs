namespace Application.AddressService.DefaultAddress.Query.Read.Dto;

public class ReadDefaultAddressResponse
{
    public int DefaultAddressId { get; set; }
    public string ProvinceName { get; set; }
    public string CityName { get; set; }
    public string FullAddress { get; set; }
    public string PostalCode { get; set; }
    public string TransfereeName { get; set; }
    public string TransfereePhone { get; set; }
}