﻿using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AddressService.NormalAddress.Query.ReadMultiple;

public class ReadMultipleAddresses : PaginatedQuery<ReadMultipleAddressRequest, ReadMultipleAddressResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ReadMultipleAddresses(IDatabaseContext databaseContext, UserManager<ApplicationUser> userManager,
        IMapper mapper) : base(databaseContext, mapper)
    {
        _userManager = userManager;
    }

    public override PaginatedResponse<ReadMultipleAddressResponse> Execute(ReadMultipleAddressRequest request)
    {
        return new PaginatedResponse<ReadMultipleAddressResponse>()
        {
            Message = { "not paginated" },
            Data = Mapper.Map<ICollection<ReadMultipleAddressResponse>>(_userManager.Users
                .Where(x => x.Id == request.UserId)
                .Include(x => x.Addresses).Select(x => x.Addresses))
        };
    }
}