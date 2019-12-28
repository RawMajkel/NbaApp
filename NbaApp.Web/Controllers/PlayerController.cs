using Microsoft.AspNetCore.Mvc;
using NbaApp.Services;
using NbaApp.Web.Responses;
using System;
using System.Collections.Generic;
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

        [HttpGet("players")]
        public async Task<ActionResult<List<PlayerResponse>>> GetAllPlayers()
        {
            var players = await _apiService.GetPlayers();
            var result = new List<PlayerResponse>();

            foreach (var player in players)
            {
                result.Add(new PlayerResponse(
                    player.ID,
                    player.NbaNetID,
                    player.FirstName,
                    player.LastName,
                    player.DateOfBirth,
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
                ));
            }

            return result;
        }

        [HttpGet("players/{teamId:guid}")]
        public async Task<ActionResult<List<PlayerResponse>>> GetPlayers(Guid teamId)
        {
            var players = await _apiService.GetPlayersFromTeam(teamId);
            var result = new List<PlayerResponse>();

            foreach (var player in players)
            {
                result.Add(new PlayerResponse(
                    player.ID,
                    player.NbaNetID,
                    player.FirstName,
                    player.LastName,
                    player.DateOfBirth,
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
                ));
            }

            return result;
        }

        [HttpGet("player-stats/{playerId:guid}")]
        public async Task<ActionResult<PlayerStatsResponse>> GetPlayerStats(Guid playerId)
        {
            var playerStats = await _apiService.GetPlayerStatsById(playerId);

            if (playerStats is null)
            {
                return NotFound();
            }

            return new PlayerStatsResponse(
                playerStats.GamesPlayed, playerStats.GamesStarted,
                playerStats.Minutes, playerStats.MinutesPerGame,
                playerStats.Points, playerStats.PointsPerGame,
                playerStats.Assists, playerStats.AssistsPerGame,
                playerStats.OffensiveRebounds, playerStats.DefensiveRebounds, playerStats.Rebounds, playerStats.ReboundsPerGame,
                playerStats.Blocks, playerStats.BlocksPerGame,
                playerStats.Steals, playerStats.StealsPerGame,
                playerStats.Fouls, playerStats.FoulsPerGame,
                playerStats.Turnovers, playerStats.TurnoversPerGame,
                playerStats.FieldGoalsAttempted, playerStats.FieldGoalsMade, playerStats.FieldGoalPercentage,
                playerStats.ThreePointersAttempted, playerStats.ThreePointersMade, playerStats.ThreePointersPercentage,
                playerStats.FreeThrowsAttempted, playerStats.FreeThrowsMade, playerStats.FreeThrowsPercentage
            );
        }

        [HttpGet("player/{firstName}/{lastName}")]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(string firstName, string lastName)
        {
            var player = await _apiService.GetPlayerByName(firstName, lastName);

            if (player is null)
            {
                return NotFound();
            }

            return new PlayerResponse(
                player.ID,
                player.NbaNetID,
                player.FirstName,
                player.LastName,
                player.DateOfBirth,
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

        [HttpGet("player/{playerId:guid}")]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(Guid playerId)
        {
            var player = await _apiService.GetPlayerById(playerId);

            if (player is null)
            {
                return NotFound();
            }

            return new PlayerResponse(
                player.ID,
                player.NbaNetID,
                player.FirstName,
                player.LastName,
                player.DateOfBirth,
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
