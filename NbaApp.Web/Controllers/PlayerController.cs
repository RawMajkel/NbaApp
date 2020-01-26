using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using NbaApp.Common.Entities;
using NbaApp.Services;
using NbaApp.Web.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class PlayersController : BaseController
    {
        public PlayersController(ApiService apiService) : base(apiService)
        {

        }

        [HttpGet("players")]
        [EnableQuery()]
        public async Task<ActionResult<PlayersResponse>> GetAllPlayers([FromQuery(Name = "perPage")] int perPage = 0, [FromQuery(Name = "page")] int page = 0)
        {
            var players = await _apiService.Get<Player>(perPage, page);

            if(players == null)
            {
                return NotFound();
            }

            var result = new PlayersResponse();
            var playerList = new List<PlayerResponse>();

            foreach (var player in players)
            {
                playerList.Add(new PlayerResponse(
                    player.Id,
                    player.NbaNetId,
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
                    player.CareerInfo.DraftTeam
                ));
            }

            result.Players = playerList;

            var responseInfo = await _apiService.GetEntityInfo<Player>(perPage);
            result.Meta = new EntityInfo(responseInfo.Item1, responseInfo.Item2);

            return result;
        }

        [HttpGet("players/{teamId:guid}")]
        public async Task<ActionResult<List<PlayerResponse>>> GetPlayers(Guid teamId)
        {
            var players = await _apiService.GetPlayersFromTeam(teamId);
            var result = new List<PlayerResponse>();

            foreach (var player in players)
            {
                var temp = new PlayerResponse(
                    player.Id,
                    player.NbaNetId,
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
                    player.CareerInfo.DraftTeam
                );
                result.Add(temp);
            }

            return result.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
        }

        [HttpGet("player-stats/{playerId:guid}")]
        public async Task<ActionResult<PlayerStatsResponse>> GetPlayerStats(Guid playerId)
        {
            var player = await _apiService.GetEntityById<Player>(playerId);

            if (player.Stats is null)
            {
                return NotFound();
            }

            return new PlayerStatsResponse(
                player.Stats.GamesPlayed, player.Stats.GamesStarted,
                player.Stats.Minutes, player.Stats.MinutesPerGame,
                player.Stats.Points, player.Stats.PointsPerGame,
                player.Stats.Assists, player.Stats.AssistsPerGame,
                player.Stats.OffensiveRebounds, player.Stats.DefensiveRebounds, 
                player.Stats.Rebounds, player.Stats.ReboundsPerGame,
                player.Stats.Blocks, player.Stats.BlocksPerGame,
                player.Stats.Steals, player.Stats.StealsPerGame,
                player.Stats.Fouls, player.Stats.FoulsPerGame,
                player.Stats.Turnovers, player.Stats.TurnoversPerGame,
                player.Stats.FieldGoalsAttempted, player.Stats.FieldGoalsMade, player.Stats.FieldGoalPercentage,
                player.Stats.ThreePointersAttempted, player.Stats.ThreePointersMade, player.Stats.ThreePointersPercentage,
                player.Stats.FreeThrowsAttempted, player.Stats.FreeThrowsMade, player.Stats.FreeThrowsPercentage
            );
        }

        [HttpGet("player/{playerId:guid}")]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(Guid playerId)
        {
            var player = await _apiService.GetEntityById<Player>(playerId);

            if (player is null)
            {
                return NotFound();
            }

            return new PlayerResponse(
                player.Id,
                player.NbaNetId,
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
                player.CareerInfo.DraftTeam
            );
        }
    }
}
