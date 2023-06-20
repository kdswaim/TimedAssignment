using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TimedAssignment.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Models.Posts;

namespace TimedAssignment.Services.PostServices
{
    public class PostService
    {
        private readonly TimedAssignmentDBContext _context;
        private IMapper _mapper;
        private readonly string _authorId;

        public PostService(IHttpContextAccessor httpContextAccessor, TimedAssignmentDBContext context, IMapper mapper)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims?.FindFirst("uId")!.Value;

            _authorId = value!;

            if(_authorId is null)
                throw new Exception("Attempted to build PostService without User Id claim.");
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreatePost(PostCreate model)
        {
            var post = _mapper.Map<Post>(model);
            post.AuthorId = _authorId;

            await _context.Posts.AddAsync(post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post?.AuthorId != _authorId)
                return false;

            _context.Posts.Remove(post);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<PostDetail> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id && x.AuthorId == _authorId);
            if(post is null)
                return new PostDetail();

            var postDetail = _mapper.Map<PostDetail>(post);

            return postDetail;
        }
    }
}