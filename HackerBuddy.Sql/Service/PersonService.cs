using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerBuddy.Sql.Service
{
    public class PersonService : IPersonService
    {
        public readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.Include(p => p.PersonSkills).ToListAsync();
        }

        public async Task<Person> GetByEmailAsync(string email)
        {
            return await _context.Persons
              .Include(p => p.PersonSkills)
              .FirstOrDefaultAsync(p => p.EmailId == email);
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons
                .Include(p => p.PersonSkills)
                .FirstOrDefaultAsync(p => p.PersonID == id);
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdateAsync(int id, Person person)
        {
            var existingPerson = await _context.Persons.FindAsync(id);
            if (existingPerson == null) return null;

            existingPerson.Name = person.Name;
            existingPerson.Location = person.Location;
            existingPerson.Experience = person.Experience;
            existingPerson.Bio = person.Bio;
            existingPerson.LookingForRole = person.LookingForRole;

            await _context.SaveChangesAsync();
            return existingPerson;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
