using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerBuddy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _skillService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var skill = await _skillService.GetByIdAsync(id);
            return skill == null ? NotFound() : Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Skill skill)
        {
            var createdSkill = await _skillService.CreateAsync(skill);
            return CreatedAtAction(nameof(GetById), new { id = createdSkill.SkillID }, createdSkill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Skill skill)
        {
            var updatedSkill = await _skillService.UpdateAsync(id, skill);
            return updatedSkill == null ? NotFound() : Ok(updatedSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _skillService.DeleteAsync(id);
            return !deleted ? NotFound() : NoContent();
        }
    }
}
