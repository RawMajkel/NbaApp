using System;

namespace NbaApp.Common.Entities
{
    public class PlayerStatsInfo
    {
        /* Properties */
        public Guid ID { get; set; } = Guid.NewGuid();
        public int GamesPlayed { get; set; }
        public int GamesStarted { get; set; }
        public int Minutes { get; set; }
        public int FieldGoalsAttempted { get; set; }
        public int FieldGoalsMade { get; set; }
        public int ThreePointersAttempted { get; set; }
        public int ThreePointersMade { get; set; }
        public int FreeThrowsAttempted { get; set; }
        public int FreeThrowsMade { get; set; }
        public int OffensiveRebounds { get; set; }
        public int DefensiveRebounds { get; set; }
        public int Assists { get; set; }
        public int Blocks { get; set; }
        public int Steals { get; set; }
        public int Fouls { get; set; }
        public int Turnovers { get; set; }
        public double MinutesPerGame { get; set; }
        public decimal FieldGoalPercentage { get; set; }
        public decimal ThreePointersPercentage { get; set; }
        public decimal FreeThrowsPercentage { get; set; }
        public int Rebounds { get; set; }
        public double ReboundsPerGame { get; set; }
        public double AssistsPerGame { get; set; }
        public double BlocksPerGame { get; set; }
        public double StealsPerGame { get; set; }
        public double FoulsPerGame { get; set; }
        public double TurnoversPerGame { get; set; }
        public int Points { get; set; }
        public int PointsPerGame { get; set; }

        /* Constructors */
        public PlayerStatsInfo()
        {

        }

        public PlayerStatsInfo(int gamesPlayed, int gamesStarted, int minutes, int fieldGoalsAttempted, int fieldGoalsMade, int threePointersAttempted, int threePointersMade, int freeThrowsAttempted, int freeThrowsMade)
        {
            GamesPlayed = gamesPlayed;
            GamesStarted = gamesStarted;
            Minutes = minutes;
            FieldGoalsAttempted = fieldGoalsAttempted;
            FieldGoalsMade = fieldGoalsMade;
            ThreePointersAttempted = threePointersAttempted;
            ThreePointersMade = threePointersMade;
            FreeThrowsAttempted = freeThrowsAttempted;
            FreeThrowsMade = freeThrowsMade;

            MinutesPerGame = Minutes / GamesPlayed;
            FieldGoalPercentage = FieldGoalsMade / FieldGoalsAttempted;
            ThreePointersPercentage = ThreePointersMade / ThreePointersAttempted;
            FreeThrowsPercentage = FreeThrowsMade / FreeThrowsAttempted;
            Rebounds = DefensiveRebounds + OffensiveRebounds;
            ReboundsPerGame = Rebounds / GamesPlayed;
            AssistsPerGame = Assists / GamesPlayed;
            BlocksPerGame = Blocks / GamesPlayed;
            StealsPerGame = Steals / GamesPlayed;
            FoulsPerGame = Fouls / GamesPlayed;
            TurnoversPerGame = Turnovers / GamesPlayed;
            Points = (FieldGoalsMade - ThreePointersMade) * 2 + ThreePointersMade * 3 + FreeThrowsMade;
            PointsPerGame = Points / GamesPlayed;
        }

        public PlayerStatsInfo(int gamesPlayed, int gamesStarted, int minutes, int fieldGoalsAttempted, int fieldGoalsMade, int threePointersAttempted, int threePointersMade, int freeThrowsAttempted, int freeThrowsMade, int offensiveRebounds, int defensiveRebounds, int assists, int blocks, int steals, int fouls, int turnovers)
            : this(gamesPlayed, gamesStarted, minutes, fieldGoalsAttempted, fieldGoalsMade, threePointersAttempted, threePointersMade, freeThrowsAttempted, freeThrowsMade)
        {
            OffensiveRebounds = offensiveRebounds;
            DefensiveRebounds = defensiveRebounds;
            Assists = assists;
            Blocks = blocks;
            Steals = steals;
            Fouls = fouls;
            Turnovers = turnovers;
        }
    }
}
