using Application.UserService.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UserService.Query.ReadMultiple;

public class ReadMultipleUsers : PaginatedQuery<ReadMultipleUsersRequest, ReadMultipleUsersResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ReadMultipleUsers(
        IDatabaseContext databaseContext,
        IMapper mapper,
        UserManager<ApplicationUser> userManager) : base(databaseContext, mapper)
    {
        _userManager = userManager;
    }

    public override PaginatedResponse<ReadMultipleUsersResponse> Execute(ReadMultipleUsersRequest request)
    {
        return new PaginatedResponse<ReadMultipleUsersResponse>()
        {
            PageNumber = request.PageNumber,
            Data = _userManager.Users
                .Include(x=>x.Comments)
                // .PagedResult(pageNum: request.PageNumber, pageSize: request.PageSize)
                .Select(x => Mapper.Map<ReadMultipleUsersResponse>(x))
        };
    }
}