using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  TimedAssignment.Models.Posts;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Comments;
using AutoMapper;
namespace TimedAssignment.Services.Configurations
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<Post,PostCreate>().ReverseMap();
            CreateMap<Post,PostEdit>().ReverseMap();
            CreateMap<Post,PostListItem>().ReverseMap();
            CreateMap<Post,PostDetail>().ReverseMap();

            CreateMap<Comment,CommentCreate>().ReverseMap();
            CreateMap<Comment,CommentEdit>().ReverseMap();
            CreateMap<Comment,CommentListItem>().ReverseMap();
            CreateMap<Comment,CommentDetail>().ReverseMap();
        }
    }
}