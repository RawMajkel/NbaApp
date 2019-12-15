using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetDraft
    {
        [JsonPropertyName("teamId")]
        public int TeamID { get; set; }

        [JsonPropertyName("pickNum")]
        public byte Pick { get; set; }

        [JsonPropertyName("roundNum")]
        public byte Round { get; set; }

        [JsonPropertyName("seasonYear")]
        public int Year { get; set; }
    }
}
