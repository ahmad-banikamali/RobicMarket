using Application.CommentService.Command.Create.AnswerComment.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.CommentService.Command.Create.AnswerComment;

public class CreateAnswerComment : Command<Comment,CreateAnswerCommentRequest>
{
    public CreateAnswerComment(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateAnswerCommentRequest request)
    {
        var parentComment = DbSet
            .Include(x=>x.ParentComment)
            .Include(x=>x.Product)
            .FirstOrDefault(x=>x.Id==request.ParentCommentId);
        
        if (parentComment == null)
            return new Response { IsSuccess = false, Message = { "parent comment not found" } };

        if (parentComment.ParentComment != null)
            return new Response { IsSuccess = false, Message = { "has grandfather!" } };

        var comment = Mapper.Map<Comment>(request); 
        comment.ProductId = parentComment.ProductId;
        DbSet.Add(comment);
        SaveChanges();
        return new Response();
    }
}