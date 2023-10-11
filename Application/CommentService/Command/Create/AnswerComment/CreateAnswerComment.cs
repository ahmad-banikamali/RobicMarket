using Application.CommentService.Command.Create.AnswerComment.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.CommentService.Command.Create.AnswerComment;

public class CreateAnswerComment : Command<CreateAnswerCommentRequest>
{
    public CreateAnswerComment(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateAnswerCommentRequest request)
    {
        var parentComment = DatabaseContext.Comments.Find(request.ParentCommentId);
        if (parentComment == null)
            return new Response { IsSuccess = false, Message = { "parent comment not found" } };

        DatabaseContext.CommentEntityEntry(parentComment).Reference(e => e.ParentComment).Load();
        DatabaseContext.CommentEntityEntry(parentComment).Reference(e => e.Product).Load();
        if (parentComment.ParentComment != null)
            return new Response { IsSuccess = false, Message = { "has grandfather!" } };

        var comment = Mapper.Map<Comment>(request); 
        comment.ProductId = parentComment.ProductId;
        DatabaseContext.Comments.Add(comment);
        DatabaseContext.SaveChanges();
        return new Response();
    }
}