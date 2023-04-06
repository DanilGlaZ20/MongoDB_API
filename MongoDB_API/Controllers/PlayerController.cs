using Microsoft.AspNetCore.Mvc;
using MongoDB_API.DTO;
using MongoDB_API.Models;
using MongoDB_API.Services;

namespace MongoDB_API.Controllers;

[ApiController]
[Route("api/players")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _service;

    public PlayerController(PlayerService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public async Task<ActionResult>
        AddNewCoach(PlayerDto playerDto)
    {
        var player= new Player() { Name = playerDto.Name, Lastname = playerDto.Lastname, Number=playerDto.Number, Position = playerDto.Position,Height = playerDto.Height};
        await _service.CreateNewPlayerAsync(player);
        return Ok(player);
    }

    [HttpGet("id/ {id:length(24)}")]
    public async Task<ActionResult>
        GetPlayerById(string id)
    {
        var result = await _service.GetPlayerByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest("not found");
    }
    
    [HttpGet("name/{name:length(4)}")]
    public async Task<ActionResult>
        GetPlayerByName(string name)
    {
        var result = await _service.GetPlayerByNameAsync(name);
        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest("not found");
    }

    [HttpGet("getPlayer")]
    public async Task<ActionResult> GetPlayer()
    {
        var result = await _service.GetPlayerAsync();
        return Ok(result);
    }

    [HttpPut("updatePlayer")]
    public async Task <ActionResult> UpdatePlayer(Player player)
    {
        await _service.UpdatePlayerAsync(player);
        return Ok(player);
    }

    [HttpDelete("delete {id:length(24)}")]
    public async Task<ActionResult> DeletePlayer(string id)
    {
        var result = await _service.GetPlayerByIdAsync(id);
        await _service.DeletePlayerAsync(id);
        return Ok(result);
    }
}