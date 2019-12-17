using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStatsStandard
    {
        [JsonPropertyName("stats")]
        public NbaNetStats Stats { get; set; }
    }
}