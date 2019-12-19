using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStatsData
    {
        [JsonPropertyName("league")]
        public NbaNetStatsLeague League { get; set; }
    }
}