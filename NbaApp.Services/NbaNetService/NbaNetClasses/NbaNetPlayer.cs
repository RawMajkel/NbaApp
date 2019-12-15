using System;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetPlayer
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("personId")]
        public int PersonID { get; set; }

        [JsonPropertyName("teamId")]
        public int TeamID { get; set; }

        [JsonPropertyName("jersey")]
        public byte JerseyNumber { get; set; }

        [JsonPropertyName("pos")]
        public string Position { get; set; }

        [JsonPropertyName("heightMeters")]
        public float HeightMetric { get; set; }

        [JsonPropertyName("weightPounds")]
        public ushort WeightLbs { get; set; }

        [JsonPropertyName("dateOfBirthUTC")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("draft")]
        public int Draft { get; set; }

        [JsonPropertyName("collegeName")]
        public string College { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
