using System;

namespace NbaApp.Common.Entities
{
    public class PlayerPosition
    {
        /* Primary Key */
        public Guid ID { get; set; } = Guid.NewGuid();

        /* Properties */
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        /* Constructors */
        public PlayerPosition()
        {

        }

        public PlayerPosition(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
