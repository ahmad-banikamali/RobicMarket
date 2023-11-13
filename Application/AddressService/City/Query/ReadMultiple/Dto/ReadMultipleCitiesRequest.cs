using Application.Common.BaseDto;

namespace Application.AddressService.City.Query.ReadMultiple.Dto;

public class ReadMultipleCitiesRequest:PaginatedRequest
{
    public int ProvinceId { get; set; }
}