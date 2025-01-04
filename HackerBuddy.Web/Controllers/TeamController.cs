using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerBuddy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _teamService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null) return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            var createdTeam = await _teamService.CreateAsync(team);
            return CreatedAtAction(nameof(GetById), new { id = createdTeam.TeamID }, createdTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Team team)
        {
            var updatedTeam = await _teamService.UpdateAsync(id, team);
            if (updatedTeam == null) return NotFound();

            return Ok(updatedTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _teamService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
