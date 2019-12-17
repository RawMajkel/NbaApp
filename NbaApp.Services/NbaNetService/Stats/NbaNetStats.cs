using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStats
    {
        [JsonPropertyName("latest")]
        public NbaNetStat Latest { get; set; }
    }
}
