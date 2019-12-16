using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeamsData
    {
        [JsonPropertyName("sports_content")]
        public NbaNetSportsContent SportsContent { get; set; }
    }
}
