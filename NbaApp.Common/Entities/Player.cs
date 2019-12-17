using System;

namespace NbaApp.Common.Entities
{
    /* IMAGE https://ak-static.cms.nba.com/wp-content/uploads/headshots/nba/latest/260x190/2544.png */
    /* STATS https://data.nba.net/prod/v1/2019/players/1628369_profile.json */

    public class Player
    {
        /* Properties */
        public Guid PlayerID { get; set; } = Guid.NewGuid();
        public string NbaNetID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public float HeightMetric { get; set; }
        public ushort HeightFeet { get; set; }
        public float HeightInches { get; set; }
        public ushort WeightPounds { get; set; }
        public float WeightKilograms { get; set; }
        public Guid CurrentTeam { get; set; }
        public PlayerStats Stats { get; set; }
        public PlayerCareerInfo CareerInfo { get; set; }

        /* Constructors */
        public Player()
        {

        }

        public Player(string firstName, string lastName, DateTime dateOfBirth, float heightMetric, ushort weightLbs, Guid currentTeam, string nbaNetId)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            HeightMetric = heightMetric;
            WeightPounds = weightLbs;
            CurrentTeam = currentTeam;
            NbaNetID = nbaNetId;

            Age = DateTime.Now.Year - DateOfBirth.Year;
            HeightFeet = Convert.ToUInt16(Math.Floor(HeightMetric * 0.393700787 * 100 / 12));
            HeightInches = (float)(HeightMetric * 0.393700787 * 100 % 12);
            WeightKilograms = (float)(WeightPounds / 2.20462262);
        }

        public Player(string firstName, string lastName, DateTime dateOfBirth, float heightMetric, ushort weightLbs, Guid currentTeam, PlayerCareerInfo careerInfo, string nbaNetId) : this(firstName, lastName, dateOfBirth, heightMetric, weightLbs, currentTeam, nbaNetId)
        {
            CareerInfo = careerInfo;
        }

        /* Methods */
        public void AddCareerInfo(PlayerCareerInfo careerInfo) => CareerInfo = careerInfo;
        public void AddStatsInfo(PlayerStats stats) => Stats = stats;
    }
}
