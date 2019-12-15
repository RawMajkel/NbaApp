﻿using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetData
    {
        [JsonPropertyName("_internal")]
        public NbaNetInternal Internal { get; set; }

        [JsonPropertyName("league")]
        public NbaNetLeague League { get; set; }
    }
}