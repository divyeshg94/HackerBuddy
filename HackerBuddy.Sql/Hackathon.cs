using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql
{
    public class Hackathon
    {
        public int HackathonID { get; set; }
        public string HackathonName { get; set; }
        public DateTime HackathonDate { get; set; }

        // Navigation properties
        public ICollection<Team> Teams { get; set; }
    }
}
