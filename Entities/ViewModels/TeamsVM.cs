namespace Entities.ViewModels
{
	public class TeamsVM
    {
        public IEnumerable<TeamVM> teams { get; set; } = new List<TeamVM>();
        public SeasonTotalsVM seasonTotals { get; set; } = new SeasonTotalsVM();
    }
}
