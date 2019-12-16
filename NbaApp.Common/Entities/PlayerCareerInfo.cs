using System;

namespace NbaApp.Common.Entities
{
    public class PlayerCareerInfo
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string College { get; set; }
        public string Country { get; set; }
        public ushort JerseyNumber { get; set; }
        public int YearsPro { get; set; }
        public string Position { get; set; }
        public ushort DraftYear { get; set; }
        public ushort DraftRound { get; set; }
        public ushort DraftPick { get; set; }
        public Guid DraftTeam { get; set; }

        /* Constructors */
        public PlayerCareerInfo()
        {

        }

        public PlayerCareerInfo(string college, string country, ushort jerseyNumber, string position, ushort draftYear, ushort draftRound, ushort draftPick, Guid draftTeam)
        {
            College = college;
            Country = country;
            JerseyNumber = jerseyNumber;
            Position = position;
            DraftYear = draftYear;
            DraftRound = draftRound;
            DraftPick = draftPick;
            DraftTeam = draftTeam;

            YearsPro = DateTime.Now.Year - DraftYear;
        }
    }
}
