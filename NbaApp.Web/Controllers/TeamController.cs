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
                    team.Division,
                    team.Statistics.Wins,
                    team.Statistics.Losses,
                    team.Statistics.GamesBehind,
                    team.Statistics.ConferenceRank,
                    team.Statistics.HomeWins,
                    team.Statistics.HomeLosses,
                    team.Statistics.AwayWins,
                    team.Statistics.AwayLosses,
                    team.Statistics.WinningStreak
                ));
            }

            return result;
        }

        [HttpGet("team/{nickName}")]
        public async Task<ActionResult<TeamResponse>> GetTeam(string nickName)
        {
            var team = await _apiService.GetTeamByNickName(nickName);

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
                team.Division,
                team.Statistics.Wins,
                team.Statistics.Losses,
                team.Statistics.GamesBehind,
                team.Statistics.ConferenceRank,
                team.Statistics.HomeWins,
                team.Statistics.HomeLosses,
                team.Statistics.AwayWins,
                team.Statistics.AwayLosses,
                team.Statistics.WinningStreak
            );
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
                team.Division,
                team.Statistics.Wins,
                team.Statistics.Losses,
                team.Statistics.GamesBehind,
                team.Statistics.ConferenceRank,
                team.Statistics.HomeWins,
                team.Statistics.HomeLosses,
                team.Statistics.AwayWins,
                team.Statistics.AwayLosses,
                team.Statistics.WinningStreak
            );
        }
    }
}
