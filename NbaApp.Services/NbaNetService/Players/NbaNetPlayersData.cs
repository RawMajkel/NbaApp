using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetPlayersData
    {
        [JsonPropertyName("_internal")]
        public NbaNetInternal Internal { get; set; }

        [JsonPropertyName("league")]
        public NbaNetLeague League { get; set; }
    }
}
