
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStandingsConferences
    {
        [JsonPropertyName("east")]
        public NbaNetStandingsConference East { get; set; }

        [JsonPropertyName("west")]
        public NbaNetStandingsConference West { get; set; }
    }
}
