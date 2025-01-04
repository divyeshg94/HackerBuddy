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
    public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext _context;

        public SkillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync() => await _context.Skills.ToListAsync();
        public async Task<Skill> GetByIdAsync(int id) => await _context.Skills.FindAsync(id);
        public async Task<Skill> CreateAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }
        public async Task<Skill> UpdateAsync(int id, Skill skill)
        {
            var existingSkill = await _context.Skills.FindAsync(id);
            if (existingSkill == null) return null;

            existingSkill.SkillName = skill.SkillName;
            await _context.SaveChangesAsync();
            return existingSkill;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
