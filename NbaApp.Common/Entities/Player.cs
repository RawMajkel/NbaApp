using System;
using NbaApp.Common.Player;

namespace NbaApp.Common.Entities
{
    public class Player
    {
        public Guid ID => Guid.NewGuid();

        /* Personal information */
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string HomeCity { get; set; }
        public string HomeCountry { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public PlayerHeight Height { get; set; }
        public PlayerWeight Weight { get; set; }

        /* Career information */
        public PlayerPosition Position { get; set; }
        public Team CurrentTeam { get; set; }
        public string HighSchool { get; set; }
        public string College { get; set; }
        public LeagueDraft Draft { get; set; }
    }
}
