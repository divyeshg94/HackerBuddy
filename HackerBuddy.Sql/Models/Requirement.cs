using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql.Models
{
    public class Requirement
    {
        public int RequirementID { get; set; }
        public int TeamID { get; set; }
        public int SkillID { get; set; }
        public int NumberOfPersons { get; set; }

        // Navigation properties
        public Team Team { get; set; }
        public Skill Skill { get; set; }
    }
}
