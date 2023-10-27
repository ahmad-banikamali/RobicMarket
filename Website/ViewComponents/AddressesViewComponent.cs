using Application.AddressService.NormalAddress.Query.ReadMultiple;
using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using Microsoft.AspNetCore.Mvc;
using Website.Utils;

namespace Website.ViewComponents;

public class AddressesViewComponent:ViewComponent
{
    private readonly ReadMultipleAddresses _readMultipleAddresses;

    public AddressesViewComponent(
        ReadMultipleAddresses readMultipleAddresses)
    {
        _readMultipleAddresses = readMultipleAddresses;
    }
    
    
    public IViewComponentResult  Invoke(string userId,int defaultAddressId)
    { 
        var addressPaginatedResponse = _readMultipleAddresses.Execute(new ReadMultipleAddressRequest()
        {
            UserId = userId
        });
        ViewBag.defaultAddressId = defaultAddressId;
        return View(addressPaginatedResponse.Data);
    }
}