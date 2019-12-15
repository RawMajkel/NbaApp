using System;

namespace NbaApp.Common.Entities
{
    public class PlayerDraftInfo
    {
        /* Properties */
        public int Year { get; set; }
        public byte Round { get; set; }
        public byte Pick { get; set; }
        public Team Team { get; set; }

        /* Auto-Implemented Properties */
        public Guid ID => Guid.NewGuid();

        /* Constructors */
        public PlayerDraftInfo(int year, byte round, byte pick)
        {
            Year = year;
            Round = round;
            Pick = pick;
        }
    }
}
