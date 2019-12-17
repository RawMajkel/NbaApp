using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeam
    {
        [JsonPropertyName("isNBAFranchise")]
        public bool IsNbaFranchise { get; set; }

        [JsonPropertyName("altCityName")]
        public string Name { get; set; }

        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        [JsonPropertyName("tricode")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("teamId")]
        public string Id { get; set; }

        [JsonPropertyName("confName")]
        public string Conference { get; set; }

        [JsonPropertyName("divName")]
        public string Division { get; set; }
    }
}
