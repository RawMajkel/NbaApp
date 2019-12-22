using System;

namespace NbaApp.Common.Entities
{
    public class TeamStats
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string TeamId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double GamesBehind { get; set; }
        public int ConferenceRank { get; set; }
        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }
        public int WinningStreak { get; set; }

        /* Constructors */
        public TeamStats()
        {

        }
        public TeamStats(string teamId, string wins, string losses, string gamesBehind, string conferenceRank, string homeWins, string homeLosses,
            string awayWins, string awayLosses, string winningStreak)
        {
            TeamId = teamId;

            Wins = int.Parse(wins);
            Losses = int.Parse(losses);
            GamesBehind = double.Parse(gamesBehind);
            ConferenceRank = int.Parse(conferenceRank);
            HomeWins = int.Parse(homeWins);
            HomeLosses = int.Parse(homeLosses);
            AwayWins = int.Parse(awayWins);
            AwayLosses = int.Parse(awayLosses);
            WinningStreak = int.Parse(winningStreak);
        }
    }
}
