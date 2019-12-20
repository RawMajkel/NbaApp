using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetStandingsStandard
    {
        [JsonPropertyName("conference")]
        public NbaNetStandingsConferences Conference { get; set; }
    }
}
