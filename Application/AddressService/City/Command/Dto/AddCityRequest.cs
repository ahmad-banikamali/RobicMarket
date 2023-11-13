namespace Application.AddressService.City.Command.Dto;

public class AddCityRequest
{
    public virtual int ProvinceId { get; set; }
    public virtual string Name { get; set; }
}