namespace EK_tracker.Models.ApiModels.Group
{
    public class GroupModel
    {
        public string Name { get; set; }
        public List<TeamStats> Teams { get; set; }
    }

    public class TeamStats
    {
        public TeamInfo Team { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int MatchesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalDifference { get; set; }
    }

    public class TeamInfo
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
