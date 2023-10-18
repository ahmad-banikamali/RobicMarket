using Application.UserService.Query.ReadMultiple;
using Application.UserService.Query.ReadMultiple.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ReadMultipleUsers _readMultipleUsers;

    public UserController(ReadMultipleUsers readMultipleUsers)
    {
        _readMultipleUsers = readMultipleUsers;
    }

    [HttpGet]
    public PaginatedResponse<ReadMultipleUsersResponse> ReadMultipleUsers([FromQuery] ReadMultipleUsersRequest request)
    {
        return _readMultipleUsers.Execute(request);
    }
}