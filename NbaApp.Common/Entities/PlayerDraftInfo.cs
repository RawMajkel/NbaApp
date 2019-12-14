using System;

namespace NbaApp.Common.Entities
{
    public class PlayerDraftInfo
    {
        /* Properties */
        public int Year { get; set; }
        public int Round { get; set; }
        public int Pick { get; set; }

        /* Auto-Implemented Properties */
        public Guid ID => Guid.NewGuid();

        /* Constructors */
        public PlayerDraftInfo(int year, int round, int pick)
        {
            Year = year;
            Round = round;
            Pick = pick;
        }
    }
}
