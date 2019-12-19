using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeamsData
    {
        [JsonPropertyName("league")]
        public NbaNetTeamsLeague League { get; set; }
    }
}
