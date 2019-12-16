using System;

namespace NbaApp.Common.Entities
{
    public class PlayerPersonalInfo
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Nationality { get; set; }
        public string HomeCity { get; set; }
        public string HomeCountry { get; set; }

        /* Constructors */
        public PlayerPersonalInfo()
        {

        }

        public PlayerPersonalInfo(string nationality, string homeCity, string homeCountry)
        {
            Nationality = nationality;
            HomeCity = homeCity;
            HomeCountry = homeCountry;
        }
    }
}
