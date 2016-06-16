namespace CommSec.Services.TeamCityStats.Models
{
    public class Statistic
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string BuildId { get; set; }
        public string BuildNumber { get; set; }
    }
}