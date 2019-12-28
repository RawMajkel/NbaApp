namespace NbaApp.Web.Responses
{
    public class TeamStatsResponse
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double GamesBehind { get; set; }
        public int ConferenceRank { get; set; }
        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }
        public int WinningStreak { get; set; }

        public TeamStatsResponse(int wins, int losses, double gamesBehind, int conferenceRank, int homeWins, int homeLosses, int awayWins, int awayLosses, int winningStreak)
        {
            Wins = wins;
            Losses = losses;
            GamesBehind = gamesBehind;
            ConferenceRank = conferenceRank;
            HomeWins = homeWins;
            HomeLosses = homeLosses;
            AwayWins = awayWins;
            AwayLosses = awayLosses;
            WinningStreak = winningStreak;
        }
    }
}
