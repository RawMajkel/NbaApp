using Microsoft.AspNetCore.Mvc;
using NbaApp.Common.Entities;
using NbaApp.Services;
using NbaApp.Web.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NbaApp.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class TeamController : BaseController
    {
        public TeamController(ApiService apiService) : base(apiService)
        {

        }

        [HttpGet("teams")]
        public async Task<ActionResult<TeamsResponse>> GetTeams([FromQuery(Name = "perPage")] int perPage = 0, [FromQuery(Name = "page")] int page = 0)
        {
            var teams = await _apiService.Get<Team>(perPage, page);

            if (teams is null)
            {
                return NotFound();
            }

            var result = new TeamsResponse();
            var teamList = new List<TeamResponse>();

            foreach (var team in teams)
            {
                teamList.Add(new TeamResponse(
                    team.Id,
                    team.NbaNetId,
                    team.Name,
                    team.NickName,
                    team.Abbreviation,
                    team.Conference,
                    team.Division,
                    team.Stats.Wins,
                    team.Stats.Losses,
                    team.Stats.GamesBehind,
                    team.Stats.ConferenceRank,
                    team.Stats.HomeWins,
                    team.Stats.HomeLosses,
                    team.Stats.AwayWins,
                    team.Stats.AwayLosses,
                    team.Stats.WinningStreak
                ));
            }

            result.Teams = teamList;

            var responseInfo = await _apiService.GetEntityInfo<Team>(perPage);
            result.Meta = new EntityInfo(responseInfo.Item1, responseInfo.Item2);

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
                team.Id,
                team.NbaNetId,
                team.Name,
                team.NickName,
                team.Abbreviation,
                team.Conference,
                team.Division,
                team.Stats.Wins,
                team.Stats.Losses,
                team.Stats.GamesBehind,
                team.Stats.ConferenceRank,
                team.Stats.HomeWins,
                team.Stats.HomeLosses,
                team.Stats.AwayWins,
                team.Stats.AwayLosses,
                team.Stats.WinningStreak
            );
        }

        [HttpGet("team/{teamId:guid}")]
        public async Task<ActionResult<TeamResponse>> GetTeam(Guid teamId)
        {
            var team = await _apiService.GetEntityById<Team>(teamId);

            if (team is null)
            {
                return NotFound();
            }

            return new TeamResponse(
                team.Id,
                team.NbaNetId,
                team.Name,
                team.NickName,
                team.Abbreviation,
                team.Conference,
                team.Division,
                team.Stats.Wins,
                team.Stats.Losses,
                team.Stats.GamesBehind,
                team.Stats.ConferenceRank,
                team.Stats.HomeWins,
                team.Stats.HomeLosses,
                team.Stats.AwayWins,
                team.Stats.AwayLosses,
                team.Stats.WinningStreak
            );
        }
    }
}
