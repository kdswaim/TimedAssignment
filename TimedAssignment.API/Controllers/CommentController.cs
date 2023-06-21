using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Services.CommentServices;
using TimedAssignment.Models;
using TimedAssignment.Models.Comments;

namespace TimedAssignment.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost] 
        public async Task<IActionResult> Post(CommentCreate model)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _commentService.CreateComment(model))
            {
                return Ok("Success");
            }
            else 
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
           var comments = await _commentService.GetComments();
            return Ok(comments);

        }
    }
    }