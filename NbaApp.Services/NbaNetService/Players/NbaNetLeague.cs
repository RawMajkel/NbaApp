using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetLeague
    {
        [JsonPropertyName("standard")]
        public List<NbaNetPlayer> Players { get; set; }
    }
}
