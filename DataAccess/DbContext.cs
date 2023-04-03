using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public partial class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }
        public virtual DbSet<DbGameOdds> GameOdds { get; set; } = null!;
        public virtual DbSet<DbTeam> Team { get; set; } = null!;
        public virtual DbSet<DbGame> Game { get; set; } = null!;
        public virtual DbSet<DbLogLoss> LogLossGame { get; set; } = null!;
    }
}
