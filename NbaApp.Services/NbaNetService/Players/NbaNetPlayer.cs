using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNetClasses
{
    public class NbaNetPlayer
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("personId")]
        public string PersonID { get; set; }

        [JsonPropertyName("teamId")]
        public string TeamID { get; set; }

        [JsonPropertyName("jersey")]
        public string JerseyNumber { get; set; }

        [JsonPropertyName("pos")]
        public string Position { get; set; }

        [JsonPropertyName("heightMeters")]
        public string HeightMetric { get; set; }

        [JsonPropertyName("weightPounds")]
        public string WeightLbs { get; set; }

        [JsonPropertyName("dateOfBirthUTC")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("draft")]
        public NbaNetDraft Draft { get; set; }

        [JsonPropertyName("collegeName")]
        public string College { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
