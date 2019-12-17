using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeamsData
    {

        [JsonPropertyName("_internal")]
        public NbaNetInternal Internal { get; set; }

        [JsonPropertyName("league")]
        public NbaNetTeamsLeague League { get; set; }
    }
}
