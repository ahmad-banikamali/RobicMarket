using Application.UserService.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UserService.Query.ReadMultiple;

public class ReadMultipleUsers : PaginatedQuery<ApplicationUser, ReadMultipleUsersRequest, ReadMultipleUsersResponse>
{
    public ReadMultipleUsers(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleUsersResponse> Execute(ReadMultipleUsersRequest request)
    {
        return new PaginatedResponse<ReadMultipleUsersResponse>()
        {
            PageNumber = request.PageNumber,
            Data = DbSet.Include(x => x.Comments)
                // .PagedResult(pageNum: request.PageNumber, pageSize: request.PageSize)
                .Select(x => Mapper.Map<ReadMultipleUsersResponse>(x))
        };
    }
}