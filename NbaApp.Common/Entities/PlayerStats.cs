using System;

namespace NbaApp.Common.Entities
{
    public class PlayerStats : BaseEntity
    {
        public int GamesPlayed { get; set; }
        public int GamesStarted { get; set; }
        public int Minutes { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int Blocks { get; set; }
        public int Steals { get; set; }
        public int Fouls { get; set; }
        public int Turnovers { get; set; }

        /* --- advanced --- */
        public int FieldGoalsAttempted { get; set; }
        public int FieldGoalsMade { get; set; }
        public int ThreePointersAttempted { get; set; }
        public int ThreePointersMade { get; set; }
        public int FreeThrowsAttempted { get; set; }
        public int FreeThrowsMade { get; set; }
        public int OffensiveRebounds { get; set; }
        public int DefensiveRebounds { get; set; }
        public double FieldGoalPercentage { get; set; }
        public double ThreePointersPercentage { get; set; }
        public double FreeThrowsPercentage { get; set; }

        /* --- per game --- */
        public double MinutesPerGame { get; set; }
        public double ReboundsPerGame { get; set; }
        public double AssistsPerGame { get; set; }
        public double BlocksPerGame { get; set; }
        public double StealsPerGame { get; set; }
        public double FoulsPerGame { get; set; }
        public double TurnoversPerGame { get; set; }
        public double PointsPerGame { get; set; }

        public PlayerStats()
        {

        }

        public PlayerStats(string gamesPlayed, string gamesStarted, string minutes, string fieldGoalsAttempted, string fieldGoalsMade, string threePointersAttempted, string threePointersMade,
            string freeThrowsAttempted, string freeThrowsMade, string offensiveRebounds, string defensiveRebounds, string assists, string blocks, string steals, string fouls, string turnovers)
        {
            GamesPlayed = RepairStat(gamesPlayed);
            GamesStarted = RepairStat(gamesStarted);
            Minutes = RepairStat(minutes);
            FieldGoalsAttempted = RepairStat(fieldGoalsAttempted);
            FieldGoalsMade = RepairStat(fieldGoalsMade);
            ThreePointersAttempted = RepairStat(threePointersAttempted);
            ThreePointersMade = RepairStat(threePointersMade);
            FreeThrowsAttempted = RepairStat(freeThrowsAttempted);
            FreeThrowsMade = RepairStat(freeThrowsMade);
            OffensiveRebounds = RepairStat(offensiveRebounds);
            DefensiveRebounds = RepairStat(defensiveRebounds);
            Assists = RepairStat(assists);
            Blocks = RepairStat(blocks);
            Steals = RepairStat(steals);
            Fouls = RepairStat(fouls);
            Turnovers = RepairStat(turnovers);

            Rebounds = DefensiveRebounds + OffensiveRebounds;
            Points = (FieldGoalsMade - ThreePointersMade) * 2 + ThreePointersMade * 3 + FreeThrowsMade;

            if (FieldGoalsAttempted != 0) FieldGoalPercentage = Math.Round(FieldGoalsMade * 1.0 / FieldGoalsAttempted, 2);
            if (ThreePointersAttempted != 0) ThreePointersPercentage = Math.Round(ThreePointersMade * 1.0 / ThreePointersAttempted, 2);
            if (FreeThrowsAttempted != 0) FreeThrowsPercentage = Math.Round(FreeThrowsMade * 1.0 / FreeThrowsAttempted, 2);

            if (GamesPlayed != 0)
            {
                MinutesPerGame = Math.Round(Minutes * 1.0 / GamesPlayed, 2);
                ReboundsPerGame = Math.Round(Rebounds * 1.0 / GamesPlayed, 2);
                AssistsPerGame = Math.Round(Assists * 1.0 / GamesPlayed, 2);
                BlocksPerGame = Math.Round(Blocks * 1.0 / GamesPlayed, 2);
                StealsPerGame = Math.Round(Steals * 1.0 / GamesPlayed, 2);
                FoulsPerGame = Math.Round(Fouls * 1.0 / GamesPlayed, 2);
                TurnoversPerGame = Math.Round(Turnovers * 1.0 / GamesPlayed, 2);
                PointsPerGame = Math.Round(Points * 1.0 / GamesPlayed, 2);
            }
        }

        private static int RepairStat(string stat)
        {
            if (string.IsNullOrEmpty(stat))
            {
                return 0;
            }

            var temp = int.Parse(stat);
            return temp < 0 ? 0 : temp;
        }
    }
}
