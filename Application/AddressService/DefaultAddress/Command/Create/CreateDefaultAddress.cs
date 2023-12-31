﻿using Application.AddressService.DefaultAddress.Command.Create.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.AddressService.DefaultAddress.Command.Create;

public class CreateDefaultAddress:Command<ApplicationUser,CreateDefaultAddressRequest>
{

    public CreateDefaultAddress(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateDefaultAddressRequest request)
    {
        var user = DbSet.FirstOrDefault(x => x.Id == request.ApplicationUserId);
        if (user == null) return new Response()
        {
            IsSuccess = false,
            Message = {"user is null"}
        };
        user.DefaultAddressId = request.DefaultAddressId;
        SaveChanges();
        return new Response();
    }
}