namespace Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;

public class ReadMultipleAddressResponse
{ 
    public string ProvinceName { get; set; }
    public string CityName { get; set; }
    public string FullAddress { get; set; }
    public string PostalCode { get; set; }
    public string TransfereeName { get; set; }
    public string TransfereePhone { get; set; }
}