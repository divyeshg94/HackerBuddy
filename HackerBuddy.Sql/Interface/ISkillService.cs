using HackerBuddy.Sql.Models;

namespace HackerBuddy.Sql.Interface
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill> GetByIdAsync(int id);
        Task<Skill> CreateAsync(Skill skill);
        Task<Skill> UpdateAsync(int id, Skill skill);
        Task<bool> DeleteAsync(int id);
    }
}
