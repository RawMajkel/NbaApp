using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NbaApp.Common.Entities;
using NbaApp.Persistance;
using System;
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
