using Application.CommentService.Command.Create.Dto;
using Application.CommentService.Query.ReadMultipleComments.Dto;
using Application.ProductService.Query.ReadSingleProduct.Dto;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Utils
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<Comment, CreateCommentRequest>().ReverseMap();
            CreateMap<Comment, CommentWithProduct>().ReverseMap();
            CreateMap<Comment, CommentWithProduct>().ReverseMap();
            
            CreateMap<Comment, ReadMultipleCommentsResponse>().ReverseMap();
        }
    }
}