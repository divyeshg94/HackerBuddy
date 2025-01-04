using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Models;

namespace HackerBuddy.Sql.Interface
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(int id, Person person);
        Task<bool> DeleteAsync(int id);
    }
}
