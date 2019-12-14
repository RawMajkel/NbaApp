using System;

namespace NbaApp.Common.Entities
{
    public class PlayerPosition
    {
        /* Properties */
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        /* Auto-Implemented Properties */
        public Guid ID => Guid.NewGuid();

        /* Constructors */
        public PlayerPosition(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
