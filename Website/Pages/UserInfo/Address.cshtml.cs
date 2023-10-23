using System.Security.Claims;
using Application.AddressService.City.Query;
using Application.AddressService.NormalAddress.Command;
using Application.AddressService.NormalAddress.Query.ReadMultiple;
using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using Application.AddressService.Province.Query;
using Application.AddressService.Province.Query.ReadMultiple.Dto;
using Application.ProductService.Product.Query.ReadMultiple;
using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.UserInfo;

[Authorize]
public class Address : PageModel
{
    private readonly ReadMultipleAddresses _readMultipleAddresses;
    private readonly AddNormalAddress _addNormalAddress;
    private readonly ReadMultipleCities _readMultipleCities;
    
    private readonly ReadMultipleProvinces _readMultipleProvinces;
    public PaginatedResponse<ReadMultipleAddressResponse> PaginatedResponse { get; set; }
    public ReadMultipleProvincesResponse ReadMultipleProvincesResponse { get; set; }
    public PaginatedResponse<ReadMultipleProvincesResponse> ProvincePaginatedResponse { get; set; }
    public Address(
        ReadMultipleAddresses readMultipleAddresses,
        AddNormalAddress addNormalAddress,
        ReadMultipleCities readMultipleCities,
        ReadMultipleProvinces readMultipleProvinces
        )
    {
        _readMultipleAddresses = readMultipleAddresses;
        _addNormalAddress = addNormalAddress;
        _readMultipleCities = readMultipleCities;
        _readMultipleProvinces = readMultipleProvinces;
    }

    public void OnGet()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        PaginatedResponse = _readMultipleAddresses.Execute(new ReadMultipleAddressRequest()
        {
            UserId = userId
        });
        ProvincePaginatedResponse = _readMultipleProvinces.Execute(new ReadMultipleProvincesRequest());
    }
}