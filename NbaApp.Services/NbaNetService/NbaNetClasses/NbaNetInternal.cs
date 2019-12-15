using System;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetInternal
    {
        [JsonPropertyName("pubDateTime")]
        public DateTime PublicationDate { get; set; }
    }
}
