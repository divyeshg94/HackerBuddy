using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Models;

namespace HackerBuddy.Sql.Interface
{
    public interface IPersonMatchingService
    {
        Task<IEnumerable<Person>> FindMatchesAsync(int personId);
    }
}
