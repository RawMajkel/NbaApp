using System;

namespace NbaApp.Common.Entities
{
    public class TeamStats
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string TeamId { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string GamesBehind { get; set; }
        public string ConferenceRank { get; set; }
        public string HomeWins { get; set; }
        public string HomeLosses { get; set; }
        public string AwayWins { get; set; }
        public string AwayLosses { get; set; }
        public string WinningStreak { get; set; }
        
        /* Constructors */
        public TeamStats()
        {

        }
    }
}
