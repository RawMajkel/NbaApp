using System;

namespace NbaApp.Common.Entities
{
    public class Player
    {
        /* Properties */
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double HeightMetric { get; set; }
        public int WeightKg { get; set; }
        public Team CurrentTeam { get; set; }
        public PlayerPersonalInfo PersonalInfo { get; set; }
        public PlayerCareerInfo CareerInfo{ get; set; }

        /* Auto-Implemented Properties */
        public Guid ID => Guid.NewGuid();
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string HeightFeet => MetricToFeetAndInches();
        public double WeightLbs => WeightKg * 2.20462262;

        /* Constructors */
        public Player(string firstName, string lastName, DateTime dateOfBirth, double heightMetric, int weightKg)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            HeightMetric = heightMetric;
            WeightKg = weightKg;
        }

        public Player(string firstName, string lastName, DateTime dateOfBirth, double heightMetric, int weightKg, Team currentTeam, PlayerPersonalInfo personalInfo, PlayerCareerInfo careerInfo) : this(firstName, lastName, dateOfBirth, heightMetric, weightKg)
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
    }
}
