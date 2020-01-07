using System;

namespace NbaApp.Common.Entities
{
    public class Team
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NbaNetId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public Guid StatisticsId { get; set; }
        public virtual TeamStats Statistics { get; set; }

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

        public void AddStats(TeamStats stats)
        {
            Statistics = stats;
        }
    }
}
