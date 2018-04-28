using Microsoft.EntityFrameworkCore;

namespace Soccernation.Models
{
    public class SoccernationContext : DbContext
    {
        public SoccernationContext(DbContextOptions<SoccernationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<ResultRow> ResultRows { get; set; }
        public DbSet<CompetitionsTeams> CompetitionsTeams { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CompetitionsCourts> CompetitionsCourts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Referee> Referees { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
    }
}
