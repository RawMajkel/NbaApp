using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeam
    {
        [JsonPropertyName("is_nba_team")]
        public bool IsNbaTeam { get; set; }

        [JsonPropertyName("team_name")]
        public string Name { get; set; }

        [JsonPropertyName("team_nickname")]
        public string NickName { get; set; }

        [JsonPropertyName("team_abbrev")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("team_id")]
        public int Id { get; set; }

        [JsonPropertyName("conference")]
        public string Conference { get; set; }

        [JsonPropertyName("division_id")]
        public string Division { get; set; }
    }
}
