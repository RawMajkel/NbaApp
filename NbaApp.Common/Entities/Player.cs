using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace NbaApp.Common.Entities
{
    /* IMAGE https://ak-static.cms.nba.com/wp-content/uploads/headshots/nba/latest/260x190/2544.png */

    public class Player
    {
        #region Properties
        public Guid ID { get; set; } = Guid.NewGuid();
        public string NbaNetID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public float HeightMetric { get; set; }
        public int HeightFeet { get; set; }
        public float HeightInches { get; set; }
        public int WeightPounds { get; set; }
        public float WeightKilograms { get; set; }
        public Guid CurrentTeam { get; set; }
        public PlayerStats Stats { get; set; }
        public PlayerCareerInfo CareerInfo { get; set; }
        #endregion

        #region Constructors
        public Player()
        {

        }

        public Player(string firstName, string lastName, string dateOfBirth, string heightMetric, string weightLbs, Guid currentTeam, string nbaNetId)
        {
            FirstName = firstName;
            LastName = lastName;
            CurrentTeam = currentTeam;
            NbaNetID = nbaNetId;
            HeightMetric = float.Parse(heightMetric, CultureInfo.InvariantCulture.NumberFormat);
            WeightPounds = int.Parse(weightLbs);

            HeightFeet = (int)Math.Floor(HeightMetric * 0.393700787 * 100 / 12);
            HeightInches = (float)(HeightMetric * 0.393700787 * 100 % 12);
            WeightKilograms = (float)(WeightPounds / 2.20462262);

            if (dateOfBirth is { })
            {
                DateOfBirth = DateTime.ParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Age = DateTime.Now.Year - DateOfBirth.Value.Year;
            }
        }
        #endregion

        #region Methods
        public void AddCareerInfo(PlayerCareerInfo careerInfo) => CareerInfo = careerInfo;
        public void AddStatsInfo(PlayerStats stats) => Stats = stats;
        #endregion
    }
}
