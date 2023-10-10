using Application.CommentService.Command.Create;
using Application.CommentService.Command.Create.Dto;
using Application.CommentService.Query.ReadMultipleComments;
using Application.CommentService.Query.ReadMultipleComments.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly CreateComment _createComment;
    private readonly ReadMultipleComments _readMultipleComments;

    public CommentController(CreateComment createComment,ReadMultipleComments readMultipleComments)
    {
        _createComment = createComment;
        _readMultipleComments = readMultipleComments;
    }
    
    [HttpPost]
    public Response OnPost(CreateCommentRequest request)
    {
        return _createComment.Execute(request);
    }
    
    [HttpGet]
    public PaginatedResponse<ReadMultipleCommentsResponse> OnGet([FromQuery] ReadMultipleCommentsRequest request)
    {
        return _readMultipleComments.Execute(request);
    }
    
}