using Application.AddressService.NormalAddress.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AddressService.NormalAddress.Command;

public class AddNormalAddress : Command<ApplicationUser,AddNormalAddressRequest>
{
    
    public AddNormalAddress(IDatabaseContext databaseContext, IMapper mapper)
        : base(databaseContext, mapper)
    {
        
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
        
        user.Addresses.Add(Mapper.Map<Address>(request));
        SaveChanges();
        return new Response();
    }
}