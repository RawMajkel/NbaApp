using NbaApp.Services.NbaNet;
using NbaApp.Persistance;
using NbaApp.Common.Entities;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using System;
using System.Globalization;

namespace NbaApp.Services
{
    public class NbaNetService
    {
        /* Fields */
        private readonly Context _context;
        private readonly NbaNetData _jsonData;

        /* Constructors */
        public NbaNetService(Context context)
        {
            _context = context;

            using WebClient client = new WebClient();
            string json = client.DownloadString("https://data.nba.net/prod/v1/2019/players.json");

            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            _jsonData = JsonSerializer.Deserialize<NbaNetData>(json, options);
        }

        /* Methods */
        public async Task LoadPlayerData(string firstName, string lastName)
        {
            var player = _jsonData.League.Players
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .Select(x => new Player(
                    x.FirstName,
                    x.LastName,
                    Convert.ToDateTime(x.DateOfBirth),
                    float.Parse(x.HeightMetric, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToUInt16(x.WeightLbs),
                    x.PersonID
                ))
                .FirstOrDefault();

            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
    }
}
