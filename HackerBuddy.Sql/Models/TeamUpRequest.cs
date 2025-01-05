using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerBuddy.Sql.Models
{
    public class TeamupRequest
    {
        public int TeamupRequestID { get; set; }
        public int RequesterID { get; set; } // Person sending the request
        public int ReceiverID { get; set; } // Person receiving the request
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected

        public ICollection<Person> Requester { get; set; }
        public ICollection<Person> Receiver { get; set; }
    }
}
