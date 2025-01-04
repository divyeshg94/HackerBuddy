using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Models;

namespace HackerBuddy.Sql.Interface
{
    public interface IConversationService
    {
        Task<IEnumerable<Conversation>> GetConversations(int fromPersonId);
        Task<Conversation> SendMessage(Conversation conversation);
    }
}
