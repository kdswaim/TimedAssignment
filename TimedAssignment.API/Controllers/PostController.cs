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
using TimedAssignment.Services.PostServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost(PostCreate newPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _postService.CreatePost(newPost))
                return Ok("Success");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPosts();
            return Ok(posts);
        }

         [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            return Ok(post);
        }
    }
}