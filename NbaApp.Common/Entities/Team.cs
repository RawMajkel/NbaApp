﻿using System;

namespace NbaApp.Common.Entities
{
    public class Team
    {
        #region Properties
        public Guid ID { get; set; } = Guid.NewGuid();
        public string NbaNetID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public TeamStats Statistics { get; set; }
        #endregion

        #region Properties
        public Team()
        {

        }

        public Team(string name, string nickName, string abbreviation, string conference, string division, string nbaNetID)
        {
            Name = name;
            NickName = nickName;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            NbaNetID = nbaNetID;
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
