using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int HackathonID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Hackathon Hackathon { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
    }
}
