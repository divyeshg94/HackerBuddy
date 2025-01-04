using Microsoft.VisualBasic;

namespace HackerBuddy.Sql
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; } // Years of experience
        public string Bio { get; set; }
        public string LookingForRole { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<PersonSkill> PersonSkills { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<Conversation> SentConversations { get; set; }
        public ICollection<Conversation> ReceivedConversations { get; set; }
    }
}
