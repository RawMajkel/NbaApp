using Microsoft.AspNetCore.Mvc;
using NbaApp.Services;
using NbaApp.Web.Responses;
using System;
using System.Threading.Tasks;

namespace NbaApp.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PlayersController : BaseController
    {
        public PlayersController(ApiService apiService) : base(apiService)
        {

        }

        [HttpGet("player-stats/{id:guid}")]
        public async Task<ActionResult<StatsResponse>> GetPlayerStats(Guid id)
        {
            var stats = await _apiService.GetPlayerStatsById(id);

            if (stats is null)
            {
                return NotFound();
            }

            return new StatsResponse(
                stats.GamesPlayed, stats.GamesStarted,
                stats.Minutes, stats.MinutesPerGame,
                stats.Points, stats.PointsPerGame,
                stats.Assists, stats.AssistsPerGame,
                stats.OffensiveRebounds, stats.DefensiveRebounds, stats.Rebounds, stats.ReboundsPerGame,
                stats.Blocks, stats.BlocksPerGame,
                stats.Steals, stats.StealsPerGame,
                stats.Fouls, stats.FoulsPerGame,
                stats.Turnovers, stats.TurnoversPerGame,
                stats.FieldGoalsAttempted, stats.FieldGoalsMade, stats.FieldGoalPercentage,
                stats.ThreePointersAttempted, stats.ThreePointersMade, stats.ThreePointersPercentage,
                stats.FreeThrowsAttempted, stats.FreeThrowsMade, stats.FreeThrowsPercentage
            );
        }

        [HttpGet("player/{id:guid}")]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(Guid id)
        {
            var player = await _apiService.GetPlayerById(id);

            if (player is null)
            {
                return NotFound();
            }

            return new PlayerResponse(
                player.FirstName,
                player.LastName,
                player.DateOfBirth,
                player.NbaNetID,
                player.Age,
                player.HeightMetric,
                player.HeightFeet,
                player.HeightInches,
                player.WeightPounds,
                player.WeightKilograms,
                player.CurrentTeam,
                player.CareerInfo.College,
                player.CareerInfo.Country,
                player.CareerInfo.JerseyNumber,
                player.CareerInfo.YearsPro,
                player.CareerInfo.Position,
                player.CareerInfo.DraftYear,
                player.CareerInfo.DraftRound,
                player.CareerInfo.DraftPick,
                player.CareerInfo.DraftTeam.GetValueOrDefault()
            );
        }
    }
}
