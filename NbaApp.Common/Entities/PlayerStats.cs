using System;

namespace NbaApp.Common.Entities
{
    public class PlayerStats
    {
        /* Primary Key */
        public Guid ID { get; set; } = Guid.NewGuid();

        /* Properties */
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

        /* Auto-Implemented Properties */
        public double MinutesPerGame => Minutes / GamesPlayed;
        public decimal FieldGoalPercentage => FieldGoalsMade / FieldGoalsAttempted;
        public decimal ThreePointersPercentage => ThreePointersMade / ThreePointersAttempted;
        public decimal FreeThrowsPercentage => FreeThrowsMade / FreeThrowsAttempted;
        public int Rebounds => DefensiveRebounds + OffensiveRebounds;
        public double ReboundsPerGame => Rebounds / GamesPlayed;
        public double AssistsPerGame => Assists / GamesPlayed;
        public double BlocksPerGame => Blocks / GamesPlayed;
        public double StealsPerGame => Steals / GamesPlayed;
        public double FoulsPerGame => Fouls / GamesPlayed;
        public double TurnoversPerGame => Turnovers / GamesPlayed;
        public int Points => (FieldGoalsMade - ThreePointersMade) * 2 + ThreePointersMade * 3 + FreeThrowsMade;
        public int PointsPerGame => Points / GamesPlayed;

        /* Constructors */
        public PlayerStats()
        {

        }

        public PlayerStats(int gamesPlayed, int gamesStarted, int minutes, int fieldGoalsAttempted, int fieldGoalsMade, int threePointersAttempted, int threePointersMade, int freeThrowsAttempted, int freeThrowsMade)
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
        }

        public PlayerStats(int gamesPlayed, int gamesStarted, int minutes, int fieldGoalsAttempted, int fieldGoalsMade, int threePointersAttempted, int threePointersMade, int freeThrowsAttempted, int freeThrowsMade, int offensiveRebounds, int defensiveRebounds, int assists, int blocks, int steals, int fouls, int turnovers)
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
