namespace Entities.Models
{
    public class Team
    {
        public int id { get; set; }
        public string locationName { get; set; } = string.Empty;
        public string teamName { get; set; } = string.Empty;
        public string logoUri { get; set; } = string.Empty;
        public double vegasLogLoss { get; set; }
        public double modelLogLoss { get; set; }
    }
}
