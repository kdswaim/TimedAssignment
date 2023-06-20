using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data.Entities;
using TimedAssignment.Data.TimedAssignmentContext;
using TimedAssignment.Models.Posts;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly TimedAssignmentDBContext _context;
        private readonly string _authorId;

        public PostController(IHttpContextAccessor httpContextAccessor, TimedAssignmentDBContext context)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims?.FindFirst("uId")!.Value;

            if(_authorId is null)
                throw new Exception("Attempted to build PostService without User Id claim.");
            _authorId = value;
            _context = context;
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost(PostCreate newPost)
        {
            Post post = new Post(){
                Title = newPost.Title,
                Text = newPost.Text,
                AuthorId = newPost.AuthorId
            };

            if(post.AuthorId != _authorId)
                return BadRequest("Author Id does not match!");

            await _context.SaveChangesAsync();

            return Ok("Successfully Added!");
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _context.Posts.Select(p=> new PostListItem
            {
                Id = p.Id,
                AuthorId = p.AuthorId,
                Title = p.Title,
                Text = p.Text,
            }).ToListAsync();

            return Ok(posts);
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsByAuthorId(int id)
        {
            var posts = await _context.Posts.FirstOrDefaultAsync(p=>p.AuthorId == id.ToString());

            if(posts == null)
                return NotFound();

            return Ok(posts);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostEdit model, int id)
        {
            var oldPost = await _context.Posts.FindAsync(id);

            if(oldPost == null)
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            if(!string.IsNullOrEmpty(model.Title))
                oldPost.Title = model.Title;

            if(!string.IsNullOrEmpty(model.Text))
                oldPost.Text = model.Text;
            
            await _context.SaveChangesAsync();
            return Ok("Succesfully Updated!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post is null)
                return NotFound();
            if (post.AuthorId == _authorId)
            _context.Posts.Remove(post);
            
            await _context.SaveChangesAsync();
            return Ok("Successfully Deleted!");
        }
    }
}