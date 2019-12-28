using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NbaApp.Common.Entities;
using NbaApp.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Services
{
    public class ApiService : BaseService
    {
        public ApiService(Context context, IConfiguration configuration) : base(context, configuration)
        {

        }

        #region Methods
        public async Task<TeamStats> GetTeamStatsById(Guid teamId)
        {
            var team = await GetTeamById(teamId);
            return team.Statistics;
        }

        public async Task<Team> GetTeamById(Guid teamId)
        {
            var team = await Task.FromResult(_context.Teams
                .Include(x => x.Statistics)
                .FirstOrDefault(x => x.ID == teamId));

            return team;
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            var teams = await Task.FromResult(_context.Teams.AsEnumerable());
            return teams;
        }

        public async Task<IEnumerable<Player>> GetPlayersFromTeam(Guid teamId)
        {
            var players = await Task.FromResult(_context.Players
                .Include(x => x.CareerInfo)
                .Where(x => x.CurrentTeam == teamId));

            return players;
        }

        public async Task<Player> GetPlayerById(Guid playerId)
        {
            return await Task.FromResult(_context.Players
                .Include(x => x.CareerInfo)
                .Include(x => x.Stats)
                .FirstOrDefault(x => x.ID == playerId));
        }

        public async Task<PlayerStats> GetPlayerStatsById(Guid playerId)
        {
            var player = await GetPlayerById(playerId);
            return player.Stats;
        }
        #endregion
    }
}
