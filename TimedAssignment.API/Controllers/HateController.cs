using TimedAssignment.Models.Hates;
using TimedAssignment.Services.HateServices;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CreateHate([FromBody] HateCreate hateCreate)
    {
        var newHate = _hateService.CreateHate(hateCreate);

        return Ok(newHate);
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
        var hates = _hateService.GetHatesByOwnerId(ownerId);

        return Ok(hates);
    }

    [HttpPut("{hateId}")]
    public IActionResult UpdateHate(int hateId, [FromBody] HateEdit hateEdit)
    {

        var updatedHate = _hateService.UpdateHate(hateId, hateEdit);

        return Ok(updatedHate);
    }

    [HttpDelete("{hateId}")]
    public IActionResult DeleteHate(int hateId)
    {
        _hateService.DeleteHate(hateId);

        return Ok();
    }
}