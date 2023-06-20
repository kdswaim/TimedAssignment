using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Hates;
using TimedAssignment.Services.HateServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HateController : ControllerBase
    {
        private readonly IHateService _hateService;

        public HateController(IHateService hateService)
        {
            _hateService = hateService;
        }

        [HttpPost]
        public IActionResult CreateHate([FromBody]  HateCreate hateCreate)
        {
            var newHate = _hateService.CreateHate(hateCreate);
            return Ok (newHate);
        }
        [HttpGet("{postId}")]
        public IActionResult GetHatesByPostId(int postId)
        {
            var hates = _hateService.GetHatesByPostId(postId);
            return Ok(hates);
        }

        [HttpGet("owner/{ownerId}")]
        public IActionResult GetHatesByOwnerId(string ownerId)
        {
            var hates = _hateService.GetHatesByPostID(GetHatesByPostId);
            return Ok(hates);
        }

        [HttpDelete("{hateId}")]
        public IActionResult DeleteHate(int hateId)
        {
            _hateService.DeleteHate(hateId);
            return Ok();
        }

        [HttpPut("{hateId}")]
        
        public IActionResult UpdateHate(int hateId, [FromBody] HateEdit hateEdit)
        return Ok(updatedHate);
        
    }
}