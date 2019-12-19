using System;

namespace NbaApp.Common.Entities
{
    public class PlayerCareerInfo
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string College { get; set; }
        public string Country { get; set; }
        public string JerseyNumber { get; set; }
        public int YearsPro { get; set; }
        public string Position { get; set; }
        public int? DraftYear { get; set; }
        public int? DraftRound { get; set; }
        public int? DraftPick { get; set; }
        public Guid? DraftTeam { get; set; }

        /* Constructors */
        public PlayerCareerInfo()
        {

        }

        public PlayerCareerInfo(string college, string country, string jerseyNumber, string position, string draftYear, string draftRound, string draftPick, string debutYear, Guid draftTeam)
        {
            College = college;
            Country = country;
            Position = position;
            DraftTeam = draftTeam;
            JerseyNumber = jerseyNumber;

            DraftYear = int.TryParse(draftYear, out int i) ? (int?)i : null;
            DraftRound = int.TryParse(draftRound, out i) ? (int?)i : null;
            DraftPick = int.TryParse(draftPick, out i) ? (int?)i : null;

            if (!string.IsNullOrEmpty(debutYear))
            {
                YearsPro = DateTime.Now.Year - int.Parse(debutYear);
            }
        }
    }
}