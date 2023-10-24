using Application.CommentService.Command.Create.ParentComment.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.CommentService.Command.Create.ParentComment;

public class CreateParentComment : Command<Comment,CreateParentCommentRequest>
{
    public CreateParentComment(IDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }


    public override Response Execute(CreateParentCommentRequest request)
    {
        DbSet.Add(Mapper.Map<Comment>(request));
        SaveChanges();
        return new Response();
    }
}