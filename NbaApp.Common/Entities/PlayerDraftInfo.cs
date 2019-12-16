using System;

namespace NbaApp.Common.Entities
{
    public class PlayerDraftInfo
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public ushort Year { get; set; }
        public ushort Round { get; set; }
        public ushort Pick { get; set; }
        public Team Team { get; set; }

        /* Constructors */
        public PlayerDraftInfo()
        {

        }

        public PlayerDraftInfo(ushort year, ushort round, ushort pick)
        {
            Year = year;
            Round = round;
            Pick = pick;
        }
    }
}
