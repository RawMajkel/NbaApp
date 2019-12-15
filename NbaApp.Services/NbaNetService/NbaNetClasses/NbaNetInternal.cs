using System;
using System.Text.Json.Serialization;

namespace NbaApp.Services.NbaNet
{
    public class NbaNetInternal
    {
        [JsonPropertyName("pubDateTime")]
        private string PrivatePublicationDate => PrivatePublicationDate.Substring(PrivatePublicationDate.Length - 3);
        public DateTime PublicationDate => Convert.ToDateTime(PrivatePublicationDate);
    }
}
