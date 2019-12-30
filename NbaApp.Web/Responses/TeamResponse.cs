using System;

namespace NbaApp.Web.Responses
{
    public class TeamResponse
    {
        public Guid Id { get; set; }
        public string NbaNetID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double GamesBehind { get; set; }
        public int ConferenceRank { get; set; }
        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }
        public int WinningStreak { get; set; }

        public TeamResponse(Guid id, string nbaNetid, string name, string nickName, string abbreviation, string conference, string division, int wins, int losses, double gamesBehind, int conferenceRank,
            int homeWins, int homeLosses, int awayWins, int awayLosses, int winningStreak)
        {
            Id = id;
            NbaNetID = nbaNetid;
            Name = name;
            NickName = nickName;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            Wins = wins;
            Losses = losses;
            GamesBehind = gamesBehind;
            ConferenceRank = conferenceRank;
            HomeWins = homeWins;
            HomeLosses = homeLosses;
            AwayWins = awayWins;
            AwayLosses = awayLosses;
            WinningStreak = winningStreak;
        }
    }
}
