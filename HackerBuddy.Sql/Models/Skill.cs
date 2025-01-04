using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }

        // Navigation properties
        public ICollection<PersonSkill> PersonSkills { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
    }
}
