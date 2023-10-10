using Application.CommentService.Command.Create.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.CommentService.Command.Create;

public class CreateComment : Command<CreateCommentRequest>
{


    public CreateComment(IDatabaseContext context, IMapper mapper) : base(context, mapper){}
    
    
    public override Response Execute(CreateCommentRequest request)
    {
        var parentComment = DatabaseContext.Comments.Find(request.ParentCommentId);
        if(parentComment!=null)
        {
            DatabaseContext.CommentEntityEntry(parentComment).Reference<Comment>(x => x.ParentComment).Load();
            if (parentComment.ParentComment != null) return new Response { IsSuccess = false, Message = { "has grandfather" } };
        }
        DatabaseContext.Comments.Add(Mapper.Map<Comment>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}