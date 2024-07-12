namespace EK_tracker.Models
{
    public class Match
    {
        public string? Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public CountryInfo? TeamA { get; set; }
        public CountryInfo? TeamB { get; set; }
    }

    public class CountryInfo
    {
        public int Score { get; set; }
        public TeamNameInfo? Team { get; set; }
    }

    public class TeamNameInfo
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
