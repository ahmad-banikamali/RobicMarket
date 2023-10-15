using Application.Utils.Identity.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.Utils.Identity;

public class IdentityMapper:Profile
{
    public IdentityMapper()
    {
        CreateMap<IdentityUser, SignUpDto>();
    }
}