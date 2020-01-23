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

        public async Task<IEnumerable<TEntity>> Get<TEntity>(int perPage = 0, int page = 0)
            where TEntity : class
        {
            var limited = perPage == 0 ? false : true;
            var offseted = page == 0 ? false : true;

            if (limited && !offseted)
            {
                return await Task.FromResult(_context.Set<TEntity>()
                    .Take(perPage)
                    .AsEnumerable());
            }
            else if (offseted && limited)
            {
                return await Task.FromResult(_context.Set<TEntity>()
                    .Skip((page - 1) * perPage)
                    .Take(perPage)
                    .AsEnumerable());
            }
            else if (offseted && !limited)
            {
                return null;
            }
            return await Task.FromResult(_context.Set<TEntity>().AsEnumerable());
        }
        public async Task<(int, int)> GetEntityInfo<TEntity>(int perPage)
            where TEntity : class
        {
            var total = await Task.FromResult(_context.Set<TEntity>().Count());

            if (perPage != 0)
            {
                return (total, total / perPage);
            }
            return (total, 1);
        }

        public async Task<TEntity> GetEntityById<TEntity>(Guid id)
            where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Player>> GetPlayersFromTeam(Guid teamId) => await Task.FromResult(_context.Players.Where(x => x.CurrentTeam == teamId));
        public async Task<Team> GetTeamByNickName(string nickName) => await _context.Teams.FirstOrDefaultAsync(x => x.NickName == nickName);
        public async Task<Player> GetPlayerByName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return null;
            }

            return await _context.Players.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
