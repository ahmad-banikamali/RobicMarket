using System.Security.Claims;
using Application.AddressService.NormalAddress.Command;
using Application.AddressService.NormalAddress.Query.ReadMultiple;
using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.UserInfo;

public class Address : PageModel
{
    private readonly ReadMultipleAddresses _readMultipleAddresses;
    private readonly AddNormalAddress _addNormalAddress;
    public PaginatedResponse<ReadMultipleAddressResponse> PaginatedResponse { get; set; }

    public Address(ReadMultipleAddresses readMultipleAddresses, AddNormalAddress addNormalAddress)
    {
        _readMultipleAddresses = readMultipleAddresses;
        _addNormalAddress = addNormalAddress;
    }

    public void OnGet()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        PaginatedResponse = _readMultipleAddresses.Execute(new ReadMultipleAddressRequest()
        {
            UserId = userId
        });
    }
}