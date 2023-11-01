namespace Entities.ViewModels
{
    public class LogLossVM
    {
        public int gameId { get; set; }
        public double draftKingsLogLoss { get; set; }
        public double bovadaLogLoss { get; set; }
        public double betMgmLogLoss { get; set; }
        public double barstoolLogLoss { get; set; }
        public double modelLogLoss { get; set; }
        public DateTime gameDate { get; set; }
    }
}
