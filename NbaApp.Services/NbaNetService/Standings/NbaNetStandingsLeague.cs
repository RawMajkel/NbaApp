using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStandingsLeague
    {
        [JsonPropertyName("standard")]
        public NbaNetStandingsStandard Standard { get; set; }
    }
}
