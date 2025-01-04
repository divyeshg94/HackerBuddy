using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql.Models
{
    public class PersonSkill
    {
        public int PersonSkillID { get; set; }
        public int PersonID { get; set; }
        public int SkillID { get; set; }
        public string SkillType { get; set; } // "Self" or "LookingFor"
        public int SkillLevel { get; set; } // Rating of skills (1-10)

        // Navigation properties
        public Person Person { get; set; }
        public Skill Skill { get; set; }
    }
}
