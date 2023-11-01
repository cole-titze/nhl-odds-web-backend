namespace Entities.ViewModels
{
    public class LogLossPointVM
    {
        public List<int> gameCounts { get; set; } = new List<int>();
        public List<double> modelLogLosses { get; set; } = new List<double>();
        public List<double> barstoolLogLosses { get; set; } = new List<double>();
        public List<double> betMgmLogLosses { get; set; } = new List<double>();
        public List<double> bovadaLogLosses { get; set; } = new List<double>();
        public List<double> draftKingsLogLosses { get; set; } = new List<double>();
    }
}
