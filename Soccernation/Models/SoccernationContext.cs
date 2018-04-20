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
        public DbSet<Match> Matches { get; set; }
    }
}
