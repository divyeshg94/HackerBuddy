using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerBuddy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;

        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetConversations(int personId)
        {
            return Ok(await _conversationService.GetConversations(personId));
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Conversation conversation)
        {
            var createdConversation = await _conversationService.SendMessage(conversation);
            return Created("", createdConversation);
        }
    }
}
