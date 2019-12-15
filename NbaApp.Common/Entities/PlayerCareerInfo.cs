using System;

namespace NbaApp.Common.Entities
{
    public class PlayerCareerInfo
    {
        /* Properties */
        public string LeagueStatus { get; set; }
        public string College { get; set; }
        public string Country { get; set; }
        public byte JerseyNumber { get; set; }
        public int Salary { get; set; }
        public PlayerDraftInfo Draft { get; set; }
        public PlayerPosition Position { get; set; }

        /* Auto-Implemented Properties */
        public Guid ID => Guid.NewGuid();
        public int YearsPro => DateTime.Now.Year - Draft.Year;

        /* Constructors */
        public PlayerCareerInfo(string leagueStatus, string college, string country, byte jerseyNumber, int salary, PlayerDraftInfo draft, PlayerPosition position)
        {
            LeagueStatus = leagueStatus;
            College = college;
            Country = country;
            JerseyNumber = jerseyNumber;
            Salary = salary;
            Draft = draft;
            Position = position;
        }
    }
}
