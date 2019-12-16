using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NbaApp.Common.Entities
{
    /* IMAGE https://ak-static.cms.nba.com/wp-content/uploads/headshots/nba/latest/260x190/2544.png */
    /* STATS https://data.nba.net/prod/v1/2019/players/1628369_profile.json */

    public class Player
    {
        /* Properties */

        [Key]
        public Guid PlayerID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float HeightMetric { get; set; }
        public ushort WeightLbs { get; set; }
        public int Age { get; set; }
        public string HeightFeet { get; set; }
        public float WeightKg { get; set; }
        public Team CurrentTeam { get; set; }
        public PlayerStats Stats { get; set; }
        public PlayerPersonalInfo PersonalInfo { get; set; }
        public PlayerCareerInfo CareerInfo { get; set; }

        [NotMapped]
        public string NbaNetID { get; set; }

        /* Constructors */
        public Player()
        {

        }

        public Player(string firstName, string lastName, DateTime dateOfBirth, float heightMetric, ushort weightLbs, string nbaNetId = null)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            HeightMetric = heightMetric;
            WeightLbs = weightLbs;
            NbaNetID = nbaNetId;

            Age = DateTime.Now.Year - DateOfBirth.Year;
            HeightFeet = MetricToFeetAndInches();
            WeightKg = (float)(WeightLbs / 2.20462262);
        }

        public Player(string firstName, string lastName, DateTime dateOfBirth, float heightMetric, ushort weightLbs, Team currentTeam, PlayerStats stats, PlayerPersonalInfo personalInfo, PlayerCareerInfo careerInfo, string nbaNetId = null) : this(firstName, lastName, dateOfBirth, heightMetric, weightLbs, nbaNetId)
        {
            CurrentTeam = currentTeam;
            Stats = stats;
            PersonalInfo = personalInfo;
            CareerInfo = careerInfo;
        }

        /* Methods */
        private string MetricToFeetAndInches()
        {
            double inches = HeightMetric * 0.393700787 * 100;
            return $"{(int) inches / 12}' {(int) inches % 12}\"";
        }
    }
}
