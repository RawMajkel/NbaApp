using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStandingsConference
    {
        [JsonPropertyName("teamId")]
        public string TeamId { get; set; }

        [JsonPropertyName("win")]
        public string Wins { get; set; }

        [JsonPropertyName("loss")]
        public string Losses { get; set; }

        [JsonPropertyName("gamesBehind")]
        public string GamesBehind { get; set; }

        [JsonPropertyName("confRank")]
        public string ConferenceRank { get; set; }

        [JsonPropertyName("homeWin")]
        public string HomeWins { get; set; }

        [JsonPropertyName("homeLoss")]
        public string HomeLosses { get; set; }

        [JsonPropertyName("awayWin")]
        public string AwayWins { get; set; }

        [JsonPropertyName("awayLoss")]
        public string AwayLosses { get; set; }

        [JsonPropertyName("streak")]
        public string WinningStreak { get; set; }
    }
}
