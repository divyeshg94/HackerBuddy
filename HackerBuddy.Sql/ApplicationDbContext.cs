using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerBuddy.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerBuddy.Sql
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PersonSkill> PersonSkills { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Hackathon> Hackathons { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<TeamupRequest> TeamupRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSkill>()
                .Property(ps => ps.SkillType)
                .HasConversion<string>();

            modelBuilder.Entity<Person>()
                .HasMany(p => p.SentConversations)
                .WithOne(c => c.FromPerson)
                .HasForeignKey(c => c.FromPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.ReceivedConversations)
                .WithOne(c => c.ToPerson)
                .HasForeignKey(c => c.ToPersonID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
