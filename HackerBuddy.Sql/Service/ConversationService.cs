using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerBuddy.Sql.Service
{
    public class ConversationService : IConversationService
    {
        private readonly ApplicationDbContext _context;

        public ConversationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conversation>> GetConversations(int fromPersonId)
        {
            return await _context.Conversations
                .Where(c => c.FromPersonID == fromPersonId || c.ToPersonID == fromPersonId)
                .ToListAsync();
        }

        public async Task<Conversation> SendMessage(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
            await _context.SaveChangesAsync();
            return conversation;
        }
    }
}
