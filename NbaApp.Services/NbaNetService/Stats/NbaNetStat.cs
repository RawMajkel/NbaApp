using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStat
    {
        [JsonPropertyName("gamesPlayed")]
        public string GamesPlayed { get; set; }

        [JsonPropertyName("gamesStarted")]
        public string GamesStarted { get; set; }

        [JsonPropertyName("min")]
        public string Minutes { get; set; }

        [JsonPropertyName("fga")]
        public string FGA { get; set; }

        [JsonPropertyName("fgm")]
        public string FGM { get; set; }

        [JsonPropertyName("tpm")]
        public string TPM { get; set; }
        
        [JsonPropertyName("tpa")]
        public string TPA { get; set; }
        
        [JsonPropertyName("ftm")]
        public string FTM { get; set; }
        
        [JsonPropertyName("fta")]
        public string FTA { get; set; }
        
        [JsonPropertyName("offReb")]
        public string OffReb { get; set; }
        
        [JsonPropertyName("defReb")]
        public string DefReb { get; set; }
        
        [JsonPropertyName("assists")]
        public string Assists { get; set; }
        
        [JsonPropertyName("blocks")]
        public string Blocks { get; set; }
        
        [JsonPropertyName("steals")]
        public string Steals { get; set; }
        
        [JsonPropertyName("pFouls")]
        public string Fouls { get; set; }
        
        [JsonPropertyName("turnovers")]
        public string Turnovers { get; set; }
    }
}