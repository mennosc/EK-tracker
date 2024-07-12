namespace EK_tracker.Models.ApiModels.Matches
{
    public class Match
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public TeamInfo TeamA { get; set; }
        public TeamInfo TeamB { get; set; }
    }

    public class TeamInfo
    {
        public int Score { get; set; }
        public Team team { get; set; }
    }

    public class Team
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
