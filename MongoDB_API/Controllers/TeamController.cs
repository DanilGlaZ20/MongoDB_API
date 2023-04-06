using Microsoft.AspNetCore.Mvc;
using MongoDB_API.DTO;
using MongoDB_API.Models;
using MongoDB_API.Services;

namespace MongoDB_API.Controllers;


    [ApiController]
    [Route("api/teams")]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _service;
    
        public TeamController(TeamService service)
        {
            _service = service;
        }
    
        [HttpPost("add")]
        public async Task<ActionResult>
            AddNewCoach(TeamDto teamDto)
        {
            var team = new Team() { Name=teamDto.Name,Conference = teamDto.Conference, Founded = teamDto.Founded, Title = teamDto.Title};
            
            await _service.CreateNewTeamAsync(team);
            return Ok(team);
        }
        [HttpGet("title/{title:length(1)}")]
        public async Task<ActionResult>
            GetTeamByTitle(int title)
        {
            var result = await _service.GetByTitleAsync(title);
            if (result != null)
            {
                return Ok(result);
            }
    
            return BadRequest("not found");
        } 
            
        

        [HttpGet("id/ {id:length(24)}")]
        public async Task<ActionResult>
            GetTeamById(string id)
        {
            var result = await _service.GetTeamByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
    
            return BadRequest("not found");
        }
    
        [HttpGet("getTeam")]
        public async Task<ActionResult> GetTeam()
        {
            var result = await _service.GetTeamAsync();
            return Ok(result);
        }
    
        [HttpPut("updateTeam")]
        public async Task<ActionResult> UpdateTeam(Team team)
        {
            await _service.UpdateTeamAsync(team);
            return Ok(team);
        }
    
        [HttpDelete("delete {id:length(24)}")]
        public async Task<ActionResult> DeleteTeam(string id)
        {
            var result = await _service.GetTeamByIdAsync(id);
            await _service.DeleteTeamAsync(id);
            return Ok(result);
        }
    }
