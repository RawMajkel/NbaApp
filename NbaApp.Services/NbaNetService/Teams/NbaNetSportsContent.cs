using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetSportsContent
    {
        [JsonPropertyName("teams")]
        public NbaNetTeams Teams { get; set; }
    }
}
