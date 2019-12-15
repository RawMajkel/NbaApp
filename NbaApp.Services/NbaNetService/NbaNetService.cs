using NbaApp.Services.NbaNet;
using NbaApp.Persistance;
using NbaApp.Common.Entities;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NbaApp.Services
{
    public class NbaNetService
    {
        /* Fields */
        private readonly Context _context;
        private readonly NbaNetPlayers _jsonData;

        /* Constructors */
        public NbaNetService(Context context)
        {
            _context = context;

            // TODO: Not working
            string jsonString = JsonSerializer.Serialize("https://data.nba.net/prod/v1/2019/players.json");
            _jsonData = JsonSerializer.Deserialize<NbaNetPlayers>(jsonString);
        }

        /* Methods */
        public async Task GetPlayerData(string firstName, string lastName)
        {
            var player = _jsonData.League.Players
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .Select(x => new Player ( 
                    x.FirstName,
                    x.LastName,
                    x.DateOfBirth,
                    x.HeightMetric,
                    x.WeightLbs
                ))
                .FirstOrDefault();

            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
    }
}
