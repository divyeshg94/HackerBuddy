using HackerBuddy.Sql.Models;

namespace HackerBuddy.Sql.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<Team> CreateAsync(Team team);
        Task<Team> UpdateAsync(int id, Team team);
        Task<bool> DeleteAsync(int id);
    }
}
