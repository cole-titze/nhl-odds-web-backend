using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DbModels
{
    public class DbLogLoss
	{
        public int id { get; set; }
        public double bovadaLogLoss { get; set; }
        public double modelLogLoss { get; set; }
        [ForeignKey("id")]
        public DbGame game { get; set; } = new DbGame();
    }
}
