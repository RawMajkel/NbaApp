using System;

namespace NbaApp.Common.Entities
{
    public class PlayerPersonalInfo
    {
        /* Primary Key */
        public Guid ID { get; set; } = Guid.NewGuid();

        /* Properties */
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
