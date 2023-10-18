using Application.UserService.Query.ReadMultiple.Dto;
using Application.Utils.Identity.Dto;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Utils.Identity;

public class IdentityMapper:Profile
{
    public IdentityMapper()
    {
        CreateMap<ApplicationUser, ReadMultipleUsersResponse>();
    }
}