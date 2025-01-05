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
    public class PersonMatchingService : IPersonMatchingService
    {
        private readonly ApplicationDbContext _context;

        public PersonMatchingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> FindMatchesAsync(int personId)
        {
            // Get the person's "looking for" skills
            var lookingForSkills = await _context.PersonSkills
                .Where(ps => ps.PersonID == personId && ps.SkillType == "LookingFor")
                .Select(ps => ps.SkillID)
                .ToListAsync();

            // Get persons who have the matching skills
            var matchingPersons = await _context.PersonSkills
                .Where(ps => lookingForSkills.Contains(ps.SkillID) && ps.SkillType == "Self")
                .Select(ps => ps.Person)
                .Distinct()
                .Where(p => p.PersonID != personId) // Exclude the same person
                .ToListAsync();

            return matchingPersons;
        }
    }
}
