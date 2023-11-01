using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DbModels
{
    public class DbLogLoss
	{
        [Key]
        public int gameId { get; set; }
        public double draftKingsLogLoss { get; set; }
        public double bovadaLogLoss { get; set; }
        public double betMgmLogLoss { get; set; }
        public double barstoolLogLoss { get; set; }
        public double modelLogLoss { get; set; }
        [ForeignKey("gameId")]
        public DbGame game { get; set; } = new DbGame();
    }
}
