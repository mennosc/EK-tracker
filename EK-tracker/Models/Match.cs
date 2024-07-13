namespace EK_tracker.Models
{
    public class Match
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public Country TeamA { get; set; }
        public Country TeamB { get; set; }
    }

    public class Country
    {
        public int Score { get; set; }
        public TeamInfo Team { get; set; }
    }

    public class TeamInfo
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
