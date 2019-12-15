using System;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetDraft
    {
        [JsonPropertyName("teamId")]
        public string TeamID { get; set; }

        [JsonPropertyName("pickNum")]
        public ushort Pick => Convert.ToUInt16(Pick);

        [JsonPropertyName("roundNum")]
        public ushort Round => Convert.ToUInt16(Round);

        [JsonPropertyName("seasonYear")]
        public ushort Year => Convert.ToUInt16(Year);
    }
}
