using HackerBuddy.Sql.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HackerBuddy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonMatchingController : ControllerBase
    {
        private readonly IPersonMatchingService _personMatchingService;

        public PersonMatchingController(IPersonMatchingService personMatchingService)
        {
            _personMatchingService = personMatchingService;
        }

        [HttpGet("{personId}/matches")]
        public async Task<IActionResult> GetMatches(int personId)
        {
            var matches = await _personMatchingService.FindMatchesAsync(personId);
            if (matches == null || !matches.Any()) return NotFound("No matches found.");

            return Ok(matches);
        }
    }
}
