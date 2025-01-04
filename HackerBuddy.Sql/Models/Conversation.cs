using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql.Models
{
    public class Conversation
    {
        public int ConversationID { get; set; }
        public int FromPersonID { get; set; }
        public int ToPersonID { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Person FromPerson { get; set; }
        public Person ToPerson { get; set; }
    }
}
