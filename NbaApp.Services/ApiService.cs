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
        /* Info */
        public async Task<UpdateInfo> GetInfo() => await Task.FromResult(_context.BaseUpdates.FirstOrDefault());

        /* Teams */
        public async Task<IEnumerable<Team>> GetTeams() => await Task.FromResult(_context.Teams.AsEnumerable());
        public async Task<Team> GetTeamById(Guid teamId) => await Task.FromResult(_context.Teams.FirstOrDefault(x => x.Id == teamId));
        public async Task<Team> GetTeamByNickName(string nickName) => await Task.FromResult(_context.Teams.FirstOrDefault(x => x.NickName == nickName));

        /* Players */
        public async Task<(int, int)> GetPlayerResponseInfo(int perPage)
        {
            var total = await Task.FromResult(_context.Players.Count());
            var lastPage = total / perPage;

            return (total, lastPage);
        }

        public async Task<IEnumerable<Player>> GetPlayers(int perPage, int page)
        {
            var limited = perPage != 0 ? true : false;
            var offseted = page != 0 ? true : false;

            if (limited && !offseted)
            {
                return await Task.FromResult(_context.Players
                    .Take(perPage)
                    .AsEnumerable());
            }
            else if (offseted && !limited)
            {
                return null;
            }
            else if (offseted && limited)
            {
                return await Task.FromResult(_context.Players
                    .Skip((page - 1) * perPage)
                    .Take(perPage)
                    .AsEnumerable());
            }
            return await Task.FromResult(_context.Players.AsEnumerable());
        }
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
