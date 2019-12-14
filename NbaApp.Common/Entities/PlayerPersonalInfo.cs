using System;

namespace NbaApp.Common.Entities
{
    public class PlayerPersonalInfo
    {
        /* Properties */
        public string Nationality { get; set; }
        public string HomeCity { get; set; }
        public string HomeCountry { get; set; }

        /* Auto-Implemented Properties */
        public Guid ID => Guid.NewGuid();

        /* Constructors */
        public PlayerPersonalInfo(string nationality, string homeCity, string homeCountry)
        {
            Nationality = nationality;
            HomeCity = homeCity;
            HomeCountry = homeCountry;
        }
    }
}
