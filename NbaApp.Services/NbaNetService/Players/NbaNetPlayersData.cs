﻿using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetPlayersData
    {
        [JsonPropertyName("league")]
        public NbaNetPlayersLeague League { get; set; }
    }
}
