using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerBuddy.Sql.Service
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.Include(t => t.TeamMembers).ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _context.Teams.Include(t => t.TeamMembers).FirstOrDefaultAsync(t => t.TeamID == id);
        }

        public async Task<Team> CreateAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateAsync(int id, Team team)
        {
            var existingTeam = await _context.Teams.FindAsync(id);
            if (existingTeam == null) return null;

            existingTeam.TeamName = team.TeamName;
            existingTeam.HackathonID = team.HackathonID;

            await _context.SaveChangesAsync();
            return existingTeam;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
