using System;

namespace NbaApp.Common.Entities
{
    public class Player
    {
        /* Primary Key */
        public Guid ID { get; set; } = Guid.NewGuid();

        /* Properties and fields */
        private readonly string _nbaNetID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float HeightMetric { get; set; }
        public ushort WeightLbs { get; set; }

        /* IMAGE https://ak-static.cms.nba.com/wp-content/uploads/headshots/nba/latest/260x190/2544.png */
        /* STATS https://data.nba.net/prod/v1/2019/players/1628369_profile.json */

        public Team CurrentTeam { get; set; }
        public PlayerPersonalInfo PersonalInfo { get; set; }
        public PlayerCareerInfo CareerInfo { get; set; }

        /* Auto-Implemented Properties */
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string HeightFeet => MetricToFeetAndInches();
        public float WeightKg => (float) (WeightLbs / 2.20462262);

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
            _nbaNetID = nbaNetId;
        }

        public Player(string firstName, string lastName, DateTime dateOfBirth, float heightMetric, ushort weightLbs, Team currentTeam, PlayerPersonalInfo personalInfo, PlayerCareerInfo careerInfo, string nbaNetId = null) : this(firstName, lastName, dateOfBirth, heightMetric, weightLbs, nbaNetId)
        {
            CurrentTeam = currentTeam;
            PersonalInfo = personalInfo;
            CareerInfo = careerInfo;
        }

        /* Methods */
        private string MetricToFeetAndInches()
        {
            double inches = HeightMetric * 0.393700787;
            return $"{(int) inches / 12}' {(int) inches % 12}\"";
        }

        public string GetNbaNetID()
        {
            return _nbaNetID;
        }
    }
}
