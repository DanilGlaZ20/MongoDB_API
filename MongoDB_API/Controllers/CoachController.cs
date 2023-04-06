using Microsoft.AspNetCore.Mvc;
using MongoDB_API.DTO;
using MongoDB_API.Models;
using MongoDB_API.Services;

namespace MongoDB_API.Controllers;
[ApiController]
[Route("api/coaches")]
public class CoachController : ControllerBase
{
    private readonly CoachService _service;

    public CoachController(CoachService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public async Task<ActionResult>
        AddNewCoach(CoachDto coachDto)
    {
        var coach = new Coach() { Name = coachDto.Name, Lastname = coachDto.Lastname };
        await _service.CreateNewCoachAsync(coach);
        return Ok(coach);
    }

    [HttpGet("id/ {id:length(24)}")]
    public async Task<ActionResult>
        GetCoachById(string id)
    {
        var result = await _service.GetCoachByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest("not found");
    }

    [HttpGet("getCoach")]
    public async Task<ActionResult> GetCoach()
    {
        var result = await _service.GetCoachAsync();
        return Ok(result);
    }

    [HttpPut("updateCoach")]
    public async Task<ActionResult> UpdateCoach(Coach coach)
    {
        await _service.UpdateCoachAsync(coach);
        return Ok(coach);
    }

    [HttpDelete("delete {id:length(24)}")]
    public async Task<ActionResult> DeleteCoach(string id)
    {
        var result = await _service.GetCoachByIdAsync(id);
        await _service.DeleteCoachAsync(id);
        return Ok(result);
    }
}