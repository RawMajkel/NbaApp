
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStandingsConferences
    {
        [JsonPropertyName("east")]
        public List<NbaNetStandingsConference> East { get; set; }

        [JsonPropertyName("west")]
        public List<NbaNetStandingsConference> West { get; set; }
    }
}
