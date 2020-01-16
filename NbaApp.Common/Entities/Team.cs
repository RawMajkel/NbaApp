using System;

namespace NbaApp.Common.Entities
{
    public class Team : BaseEntity
    {
        public string NbaNetId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public Guid StatisticsId { get; set; }
        public virtual TeamStats Stats { get; set; }

        public Team()
        {

        }

        public Team(string name, string nickName, string abbreviation, string conference, string division, string nbaNetID)
        {
            Name = name.Replace(nickName, "");
            NickName = nickName;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            NbaNetId = nbaNetID;
        }
    }
}
