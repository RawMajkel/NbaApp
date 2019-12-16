using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetDraft
    {
        [JsonPropertyName("teamId")]
        public string TeamID { get; set; }

        [JsonPropertyName("pickNum")]
        public string Pick { get; set; }

        [JsonPropertyName("roundNum")]
        public string Round { get; set; }

        [JsonPropertyName("seasonYear")]
        public string Year { get; set; }
    }
}
