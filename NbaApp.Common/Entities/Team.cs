using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NbaApp.Common.Entities
{
    public class Team
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }

        [NotMapped]
        public string NbaNetID { get; set; }

        /* Constructors */
        public Team()
        {

        }

        public Team(string name, string nickName, string abbreviation, string conference, string division, string nbaNetID = null)
        {
            Name = name;
            NickName = nickName;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            NbaNetID = nbaNetID;
        }
    }
}
