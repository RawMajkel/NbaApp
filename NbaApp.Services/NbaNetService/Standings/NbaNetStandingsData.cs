using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStandingsData
    {
        [JsonPropertyName("league")]
        public NbaNetStandingsLeague League { get; set; }
    }
}
