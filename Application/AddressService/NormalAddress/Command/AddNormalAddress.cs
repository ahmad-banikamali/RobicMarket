using Application.AddressService.DefaultAddress.Command.Create;
using Application.AddressService.DefaultAddress.Command.Create.Dto;
using Application.AddressService.NormalAddress.Command.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AddressService.NormalAddress.Command;

public class AddNormalAddress : Command<ApplicationUser,AddNormalAddressRequest>
{
    private readonly CreateDefaultAddress _createDefaultAddress;

    public AddNormalAddress(IDatabaseContext databaseContext,CreateDefaultAddress createDefaultAddress, IMapper mapper)
        : base(databaseContext, mapper)
    {
        _createDefaultAddress = createDefaultAddress;
    }

    public override Response Execute(AddNormalAddressRequest request)
    {
        var user =DbSet.Include(x => x.Addresses)
            .FirstOrDefault(x => x.Id == request.UserId);

        if (user == null)
            return new Response()
            {
                IsSuccess = false,
                Message = { "user not found" }
            };

        var address = Mapper.Map<Address>(request);
        user.Addresses.Add(address);
        SaveChanges();

        if (user.Addresses.Count != 1) 
            return new Response();
        
        _createDefaultAddress.Execute(new CreateDefaultAddressRequest()
            { DefaultAddressId = address.Id, ApplicationUserId = user.Id });
        SaveChanges();

        return new Response();
    }
}