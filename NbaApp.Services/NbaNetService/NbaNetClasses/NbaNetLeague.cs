using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetLeague
    {
        [JsonPropertyName("standard")]
        public List<NbaNetPlayer> Players { get; set; }
    }
}
