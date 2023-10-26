using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AddressService.NormalAddress.Query.ReadMultiple;

public class ReadMultipleAddresses : PaginatedQuery<ApplicationUser,ReadMultipleAddressRequest, ReadMultipleAddressResponse>
{
 

    public ReadMultipleAddresses(IDatabaseContext databaseContext,
        IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleAddressResponse> Execute(ReadMultipleAddressRequest request)
    {
        var queryable = (DbSet
                .Include(x => x.Addresses)
                .ThenInclude(x=>x.City)
                .ThenInclude(x=>x.Province)
                .Where(x => x.Id == request.UserId)
                .Select(x => x.Addresses)
                .FirstOrDefault() ?? new List<Address>())
            .OrderByDescending(x=>x.Id).ToList();


        return new PaginatedResponse<ReadMultipleAddressResponse>()
        {
            Message = { "not paginated" },
            Data = Mapper.Map<ICollection<Address>, ICollection<ReadMultipleAddressResponse>>(queryable)
        };
    }
}