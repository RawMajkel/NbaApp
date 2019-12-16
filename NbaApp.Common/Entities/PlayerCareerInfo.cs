using System;

namespace NbaApp.Common.Entities
{
    public class PlayerCareerInfo
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string LeagueStatus { get; set; }
        public string College { get; set; }
        public string Country { get; set; }
        public ushort JerseyNumber { get; set; }
        public int Salary { get; set; }
        public int YearsPro { get; set; }
        public PlayerDraftInfo Draft { get; set; }
        public PlayerPosition Position { get; set; }

        /* Constructors */
        public PlayerCareerInfo()
        {

        }

        public PlayerCareerInfo(string leagueStatus, string college, string country, ushort jerseyNumber, int salary, PlayerDraftInfo draft, PlayerPosition position)
        {
            LeagueStatus = leagueStatus;
            College = college;
            Country = country;
            JerseyNumber = jerseyNumber;
            Salary = salary;
            Draft = draft;
            Position = position;

            YearsPro = DateTime.Now.Year - Draft.Year;
        }
    }
}
