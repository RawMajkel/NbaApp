using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeams
    {
        [JsonPropertyName("team")]
        public List<NbaNetTeam> Teams { get; set; }
    }
}
