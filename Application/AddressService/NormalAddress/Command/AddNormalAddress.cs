using Application.AddressService.NormalAddress.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AddressService.NormalAddress.Command;

public class AddNormalAddress : Command<AddNormalAddressRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AddNormalAddress(IDatabaseContext databaseContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        : base(databaseContext, mapper)
    {
        _userManager = userManager;
    }

    public override Response Execute(AddNormalAddressRequest request)
    {
        var user = _userManager.Users.Include(x => x.Addresses)
            .FirstOrDefault(x => x.Id == request.UserId);

        if (user == null)
            return new Response()
            {
                IsSuccess = false,
                Message = { "user not found" }
            };
        
        user.Addresses.Add(Mapper.Map<Address>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}