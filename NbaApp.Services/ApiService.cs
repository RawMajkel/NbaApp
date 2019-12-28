using Microsoft.EntityFrameworkCore;
using NbaApp.Common.Entities;
using NbaApp.Persistance;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Services
{
    public class ApiService
    {
        #region Fields
        private readonly Context _context;
        #endregion

        #region Constructors
        public ApiService(Context context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<Player> GetPlayerById(Guid playerId)
        {
            return await Task.FromResult(_context.Players
                .Include(x => x.CareerInfo)
                .FirstOrDefault(x => x.ID == playerId));
        }
        #endregion
    }
}
