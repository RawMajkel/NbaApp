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
    public class TeamController : BaseController
    {
        public TeamController(ApiService apiService) : base(apiService)
        {

        }

        [HttpGet("team-stats/{teamId:guid}")]
        public async Task<ActionResult<TeamStatsResponse>> GetTeamStats(Guid teamId)
        {
            var teamStats = await _apiService.GetTeamStatsById(teamId);

            if (teamStats is null)
            {
                return NotFound();
            }

            return new TeamStatsResponse(
                teamStats.Wins,
                teamStats.Losses,
                teamStats.GamesBehind,
                teamStats.ConferenceRank,
                teamStats.HomeWins,
                teamStats.HomeLosses,
                teamStats.AwayWins,
                teamStats.AwayLosses,
                teamStats.WinningStreak
            );
        }

        [HttpGet("teams")]
        public async Task<ActionResult<List<TeamResponse>>> GetTeams()
        {
            var teams = await _apiService.GetTeams();
            var result = new List<TeamResponse>();

            if (teams is null)
            {
                return NotFound();
            }

            foreach (var team in teams)
            {
                result.Add(new TeamResponse(
                    team.NbaNetID,
                    team.Name,
                    team.NickName,
                    team.Abbreviation,
                    team.Conference,
                    team.Division
                ));
            }

            return result;
        }

        [HttpGet("team/{teamId:guid}")]
        public async Task<ActionResult<TeamResponse>> GetTeam(Guid teamId)
        {
            var team = await _apiService.GetTeamById(teamId);

            if (team is null)
            {
                return NotFound();
            }

            return new TeamResponse(
                team.NbaNetID,
                team.Name,
                team.NickName,
                team.Abbreviation,
                team.Conference,
                team.Division
            );
        }
    }
}
