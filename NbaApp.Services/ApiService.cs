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
        /* Teams */
        public async Task<IEnumerable<Team>> GetTeams() => await Task.FromResult(_context.Teams.AsEnumerable());
        public async Task<Team> GetTeamById(Guid teamId) => await Task.FromResult(_context.Teams.FirstOrDefault(x => x.Id == teamId));
        public async Task<Team> GetTeamByNickName(string nickName) => await Task.FromResult(_context.Teams.FirstOrDefault(x => x.NickName == nickName));

        /* Players */
        public async Task<IEnumerable<Player>> GetPlayers() => await Task.FromResult(_context.Players.AsEnumerable());
        public async Task<Player> GetPlayerById(Guid playerId) => await Task.FromResult(_context.Players.FirstOrDefault(x => x.Id == playerId));
        public async Task<IEnumerable<Player>> GetPlayersFromTeam(Guid teamId) => await Task.FromResult(_context.Players.Where(x => x.CurrentTeam == teamId));
        public async Task<Player> GetPlayerByName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Invalid parameters");
                return null;
            }

            var player = await Task.FromResult(_context.Players.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName));
            return player;
        }

        public async Task<PlayerStats> GetPlayerStatsById(Guid playerId)
        {
            var player = await GetPlayerById(playerId);
            return player.Stats;
        }
        #endregion
    }
}
