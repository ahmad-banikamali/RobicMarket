using Application.CommentService.Command.Create.AnswerComment;
using Application.CommentService.Command.Create.AnswerComment.Dto;
using Application.CommentService.Command.Create.ParentComment;
using Application.CommentService.Command.Create.ParentComment.Dto;
using Application.CommentService.Query.ReadMultipleComments;
using Application.CommentService.Query.ReadMultipleComments.Dto;
using Common.BaseDto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly CreateParentComment _createParentComment;
    private readonly CreateAnswerComment _createAnswerComment;
    private readonly ReadMultipleComments _readMultipleComments;
    private readonly UserManager<ApplicationUser> _userManager;

    public CommentController(
        CreateParentComment createParentComment,
        CreateAnswerComment createAnswerComment,
        ReadMultipleComments readMultipleComments,
        UserManager<ApplicationUser> userManager)
    {
        _createParentComment = createParentComment;
        _createAnswerComment = createAnswerComment;
        _readMultipleComments = readMultipleComments;
        _userManager = userManager;
    }

    [HttpPost(template:"commentToProduct")]
    public Response OnPost(CreateParentCommentRequest request)
    {
       
        return _createParentComment.Execute(request);
    }


    [HttpPost(template:"answerToComment")]
    public Response OnPost(CreateAnswerCommentRequest request)
    {
        return _createAnswerComment.Execute(request);
    }

    [HttpGet]
    public PaginatedResponse<ReadMultipleCommentsResponse> OnGet([FromQuery] ReadMultipleCommentsRequest request)
    {
        return _readMultipleComments.Execute(request);
    }
}