using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public partial class PredictedGameDbContext : DbContext
    {
        public PredictedGameDbContext(DbContextOptions<PredictedGameDbContext> options) : base(options)
        {
        }
        public virtual DbSet<DbPredictedGame> PredictedGame { get; set; }
    }
}

