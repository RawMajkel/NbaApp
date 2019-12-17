using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStatsData
    {
        [JsonPropertyName("_internal")]
        public NbaNetInternal Internal { get; set; }

        [JsonPropertyName("league")]
        public NbaNetStatsLeague League { get; set; }
    }
}