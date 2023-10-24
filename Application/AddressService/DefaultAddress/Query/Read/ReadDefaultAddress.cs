using Application.AddressService.DefaultAddress.Query.Read.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AddressService.DefaultAddress.Query.Read;

public class ReadDefaultAddress:Query<ApplicationUser,ReadDefaultAddressRequest,ReadDefaultAddressResponse>
{
     

    public ReadDefaultAddress(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
   
    }

    public override Response<ReadDefaultAddressResponse> Execute(ReadDefaultAddressRequest request)
    {
        var address = DbSet.Include(x=>x.DefaultAddress).Where(x=>x.Id==request.ApplicationUserId).Select(x=>x.DefaultAddress).FirstOrDefault();
        return new Response<ReadDefaultAddressResponse>
        {
            Data = Mapper.Map<ReadDefaultAddressResponse>(address)
        };
    }
}