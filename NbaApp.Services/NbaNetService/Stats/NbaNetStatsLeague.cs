using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStatsLeague
    {
        [JsonPropertyName("standard")]
        public NbaNetStatsStandard Standard { get; set; }
    }
}
