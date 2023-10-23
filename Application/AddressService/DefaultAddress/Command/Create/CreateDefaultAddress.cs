using Application.AddressService.DefaultAddress.Command.Create.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.AddressService.DefaultAddress.Command.Create;

public class CreateDefaultAddress:Command<CreateDefaultAddressRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateDefaultAddress(IDatabaseContext databaseContext,UserManager<ApplicationUser> userManager, IMapper mapper) : base(databaseContext, mapper)
    {
        _userManager = userManager;
    }

    public override Response Execute(CreateDefaultAddressRequest request)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == request.ApplicationUserId);
        if (user == null) return new Response()
        {
            IsSuccess = false,
            Message = {"user is null"}
        };
        user.DefaultAddressId = request.DefaultAddressId;
        DatabaseContext.SaveChanges();
        return new Response();
    }
}