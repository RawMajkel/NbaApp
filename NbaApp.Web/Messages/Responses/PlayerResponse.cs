﻿using System;

namespace NbaApp.Web.Messages.Responses
{
    public class PlayerResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NbaNetID { get; set; }
        public int Age { get; set; }
        public float HeightMetric { get; set; }
        public int HeightFeet { get; set; }
        public float HeightInches { get; set; }
        public int WeightPounds { get; set; }
        public float WeightKilograms { get; set; }
        public Guid CurrentTeam { get; set; }
        public string College { get; set; }
        public string Country { get; set; }
        public string JerseyNumber { get; set; }
        public int YearsPro { get; set; }
        public string Position { get; set; }
        public int? DraftYear { get; set; }
        public int? DraftRound { get; set; }
        public int? DraftPick { get; set; }
        public Guid DraftTeam { get; set; }

        public PlayerResponse(string firstName, string lastName, DateTime? dateOfBirth, string nbaNetID, int age, float heightMetric, int heightFeet, float heightInches, int weightPounds, float weightKilograms, Guid currentTeam)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NbaNetID = nbaNetID;
            Age = age;
            HeightMetric = heightMetric;
            HeightFeet = heightFeet;
            HeightInches = heightInches;
            WeightPounds = weightPounds;
            WeightKilograms = weightKilograms;
            CurrentTeam = currentTeam;
        }

        public PlayerResponse(string firstName, string lastName, DateTime? dateOfBirth, string nbaNetID, int age, float heightMetric, int heightFeet, float heightInches, int weightPounds, float weightKilograms,
            Guid currentTeam, string college, string country, string jerseyNumber, int yearsPro, string position, int? draftYear, int? draftRound, int? draftPick, Guid draftTeam)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NbaNetID = nbaNetID;
            Age = age;
            HeightMetric = heightMetric;
            HeightFeet = heightFeet;
            HeightInches = heightInches;
            WeightPounds = weightPounds;
            WeightKilograms = weightKilograms;
            CurrentTeam = currentTeam;
            College = college;
            Country = country;
            JerseyNumber = jerseyNumber;
            YearsPro = yearsPro;
            Position = position;
            DraftYear = draftYear;
            DraftRound = draftRound;
            DraftPick = draftPick;
            DraftTeam = draftTeam;
        }
    }
}
