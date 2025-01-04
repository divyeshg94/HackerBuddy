using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql
{
    public class TeamMember
    {
        public int TeamMemberID { get; set; }
        public int TeamID { get; set; }
        public int PersonID { get; set; }

        // Navigation properties
        public Team Team { get; set; }
        public Person Person { get; set; }
    }
}
