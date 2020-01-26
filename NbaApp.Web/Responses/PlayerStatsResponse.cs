namespace NbaApp.Web.Responses
{
    public class PlayerStatsResponse
    {
        #region Properties
        public int GamesPlayed { get; set; }
        public int GamesStarted { get; set; }
        public int Minutes { get; set; }
        public double MinutesPerGame { get; set; }
        public int Points { get; set; }
        public double PointsPerGame { get; set; }
        public int Assists { get; set; }
        public double AssistsPerGame { get; set; }
        public int OffensiveRebounds { get; set; }
        public int DefensiveRebounds { get; set; }
        public int Rebounds { get; set; }
        public double ReboundsPerGame { get; set; }
        public int Blocks { get; set; }
        public double BlocksPerGame { get; set; }
        public int Steals { get; set; }
        public double StealsPerGame { get; set; }
        public int Fouls { get; set; }
        public double FoulsPerGame { get; set; }
        public int Turnovers { get; set; }
        public double TurnoversPerGame { get; set; }
        public int FieldGoalsAttempted { get; set; }
        public int FieldGoalsMade { get; set; }
        public double FieldGoalPercentage { get; set; }
        public int ThreePointersAttempted { get; set; }
        public int ThreePointersMade { get; set; }
        public double ThreePointersPercentage { get; set; }
        public int FreeThrowsAttempted { get; set; }
        public int FreeThrowsMade { get; set; }
        public double FreeThrowsPercentage { get; set; }
        #endregion

        public PlayerStatsResponse(int gamesPlayed, int gamesStarted, int minutes, double minutesPerGame, int points, double pointsPerGame, int assists, double assistsPerGame, int offensiveRebounds,
            int defensiveRebounds, int rebounds, double reboundsPerGame, int blocks, double blocksPerGame, int steals, double stealsPerGame, int fouls, double foulsPerGame, int turnovers,
            double turnoversPerGame, int fieldGoalsAttempted, int fieldGoalsMade, double fieldGoalPercentage, int threePointersAttempted, int threePointersMade, double threePointersPercentage,
            int freeThrowsAttempted, int freeThrowsMade, double freeThrowsPercentage)
        {
            GamesPlayed = gamesPlayed;
            GamesStarted = gamesStarted;
            Minutes = minutes;
            MinutesPerGame = minutesPerGame;
            Points = points;
            PointsPerGame = pointsPerGame;
            Assists = assists;
            AssistsPerGame = assistsPerGame;
            OffensiveRebounds = offensiveRebounds;
            DefensiveRebounds = defensiveRebounds;
            Rebounds = rebounds;
            ReboundsPerGame = reboundsPerGame;
            Blocks = blocks;
            BlocksPerGame = blocksPerGame;
            Steals = steals;
            StealsPerGame = stealsPerGame;
            Fouls = fouls;
            FoulsPerGame = foulsPerGame;
            Turnovers = turnovers;
            TurnoversPerGame = turnoversPerGame;
            FieldGoalsAttempted = fieldGoalsAttempted;
            FieldGoalsMade = fieldGoalsMade;
            FieldGoalPercentage = fieldGoalPercentage;
            ThreePointersAttempted = threePointersAttempted;
            ThreePointersMade = threePointersMade;
            ThreePointersPercentage = threePointersPercentage;
            FreeThrowsAttempted = freeThrowsAttempted;
            FreeThrowsMade = freeThrowsMade;
            FreeThrowsPercentage = freeThrowsPercentage;
        }
    }
}
