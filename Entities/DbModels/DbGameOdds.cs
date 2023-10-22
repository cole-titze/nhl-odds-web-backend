using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DbModels
{
    public class DbGameOdds
    {
        [Key]
        public int gameId { get; set; }
        public double draftKingsHomeOdds { get; set; }
        public double draftKingsAwayOdds { get; set; }
        public double bovadaHomeOdds { get; set; }
        public double bovadaAwayOdds { get; set; }
        public double betMgmHomeOdds { get; set; }
        public double betMgmAwayOdds { get; set; }
        public double barstoolHomeOdds { get; set; }
        public double barstoolAwayOdds { get; set; }
        public double modelHomeOdds { get; set; }
        public double modelAwayOdds { get; set; }
        [ForeignKey("gameId")]
        public DbGame game { get; set; } = null!;
    }
}
