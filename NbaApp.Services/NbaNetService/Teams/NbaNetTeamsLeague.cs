using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetTeamsLeague
    {
        [JsonPropertyName("standard")]
        public List<NbaNetTeam> Teams { get; set; }
    }
}
