using System;
using System.Globalization;

namespace NbaApp.Common.Entities
{
    public class Player : BaseEntity
    {
        public string NbaNetId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int? Age { get; set; }
        public float? HeightMetric { get; set; }
        public int? HeightFeet { get; set; }
        public float? HeightInches { get; set; }
        public int? WeightPounds { get; set; }
        public float? WeightKilograms { get; set; }
        public Guid CurrentTeam { get; set; }
        public Guid StatsId { get; set; }
        public Guid CareerInfoId { get; set; }
        public virtual PlayerStats Stats { get; set; }
        public virtual PlayerCareerInfo CareerInfo { get; set; }

        public Player()
        {

        }

        public Player(string firstName, string lastName, string dateOfBirth, string heightMetric, string weightLbs, Guid currentTeam, string nbaNetId)
        {
            FirstName = firstName;
            LastName = lastName;
            CurrentTeam = currentTeam;
            NbaNetId = nbaNetId;
            DateOfBirth = dateOfBirth;

            if (float.TryParse(heightMetric, out _))
            {
                HeightMetric = float.Parse(heightMetric, CultureInfo.InvariantCulture.NumberFormat);
                HeightFeet = (int)Math.Floor(HeightMetric.Value * 0.393700787 * 100 / 12);
                HeightInches = (float)(Math.Round((double)(HeightMetric * 0.393700787 * 100 % 12), 2));
            }
            else
            {
                HeightMetric = null;
                HeightFeet = null;
                HeightInches = null;
            }

            if (int.TryParse(weightLbs, out int i))
            {
                WeightPounds = i;
                WeightKilograms = (float)(Math.Round((double)(WeightPounds / 2.20462262), 2));
            }
            else
            {
                WeightPounds = null;
                WeightKilograms = null;
            }

            if (!string.IsNullOrEmpty(dateOfBirth))
            {
                var birthDate = DateTime.Parse(dateOfBirth, new CultureInfo("pl-PL"));
                var today = DateTime.Today;

                Age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-Age.Value)) Age--;
            }
            else
            {
                Age = null;
                DateOfBirth = null;
            }
        }
    }
}
