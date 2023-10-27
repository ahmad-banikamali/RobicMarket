using System.Security.Claims;
using Application.AddressService.City.Query;
using Application.AddressService.City.Query.ReadMultiple.Dto;
using Application.AddressService.DefaultAddress.Command.Create;
using Application.AddressService.DefaultAddress.Command.Create.Dto;
using Application.AddressService.DefaultAddress.Query.Read;
using Application.AddressService.DefaultAddress.Query.Read.Dto;
using Application.AddressService.NormalAddress.Command;
using Application.AddressService.NormalAddress.Command.Dto;
using Application.AddressService.NormalAddress.Query.ReadMultiple;
using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using Application.AddressService.Province.Query;
using Application.AddressService.Province.Query.ReadMultiple.Dto;
using Application.ProductService.Product.Query.ReadMultiple;
using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website.Utils;
using Website.ViewComponents;

namespace Website.Pages.UserInfo;

[Authorize]
public class Address : PageModel
{ 
    private readonly AddNormalAddress _addNormalAddress; 
    
    private readonly ReadMultipleProvinces _readMultipleProvinces;
    private readonly ReadDefaultAddress _readDefaultAddress;
    private readonly CreateDefaultAddress _createDefaultAddress;

    public PaginatedResponse<ReadMultipleAddressResponse> AddressPaginatedResponse { get; set; }  
    public PaginatedResponse<ReadMultipleProvincesResponse> ProvincePaginatedResponse { get; set; }
 
    [BindProperty] public AddNormalAddressRequest AddNormalAddressRequest { get; set; } = new();
    
    public string UserId { get; set; }

    public int DefaultAddressID { get; set; }
      
    
    public Address( 
        AddNormalAddress addNormalAddress,
        ReadMultipleCities readMultipleCities,
        ReadMultipleProvinces readMultipleProvinces,
        ReadDefaultAddress readDefaultAddress,
        CreateDefaultAddress createDefaultAddress
        )
    { 
        _addNormalAddress = addNormalAddress; 
        _readMultipleProvinces = readMultipleProvinces;
        _readDefaultAddress = readDefaultAddress;
        _createDefaultAddress = createDefaultAddress;
    }

    public void OnGet()
    {
        LoadPageData();
    }

    private void LoadPageData()
    {
        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
       
        var response = _readDefaultAddress.Execute(new ReadDefaultAddressRequest() { ApplicationUserId = UserId });
        if (response.Data != null)
            DefaultAddressID = response.Data.DefaultAddressId;


        ProvincePaginatedResponse = _readMultipleProvinces.Execute(new ReadMultipleProvincesRequest());
    }

    public IActionResult OnPost()
    {
        _addNormalAddress.Execute(AddNormalAddressRequest);
        LoadPageData();
        return ViewComponent(typeof(AddressesViewComponent),new {userId=UserId});
    }


    public IActionResult OnPostGetCities(string selectedProvinceId)
    {  
        return ViewComponent(typeof(CityViewComponent),new
        {
            provinceId = int.Parse(selectedProvinceId), 
        });
    }

    public void OnPostChangeDefaultAddress(int defaultAddressId)
    {
        if(this.GetUserId()==null) Page();
        _createDefaultAddress.Execute(new CreateDefaultAddressRequest
        {
            ApplicationUserId = this.GetUserId()!,
            DefaultAddressId = defaultAddressId
        });
        LoadPageData();
    }
}