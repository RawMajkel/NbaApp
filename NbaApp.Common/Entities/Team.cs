using System;

namespace NbaApp.Common.Entities
{
    public class Team
    {
        #region Properties
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NbaNetId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public Guid StatisticsId { get; set; }
        public virtual TeamStats Statistics { get; set; }
        #endregion

        #region Properties
        public Team()
        {

        }

        public Team(string name, string nickName, string abbreviation, string conference, string division, string nbaNetID)
        {
            Console.WriteLine(" - adding team: {0}", nickName);

            if(name.Contains(" "))
            {
                Name = name.Substring(0, name.IndexOf(" "));
            }
            else
            {
                Name = name;
            }

            Name = name;
            NickName = nickName;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            NbaNetId = nbaNetID;
        }
        #endregion

        #region Methods
        public void AddStats(TeamStats stats)
        {
            Statistics = stats;
        }
        #endregion
    }
}
