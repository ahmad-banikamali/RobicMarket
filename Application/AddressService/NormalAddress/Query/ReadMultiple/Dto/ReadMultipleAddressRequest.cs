using Application.Common.BaseDto;

namespace Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;

public class ReadMultipleAddressRequest:PaginatedRequest
{
    public string UserId { get; set; }   
}