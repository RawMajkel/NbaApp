using NbaApp.Common.Entities;
using NbaApp.Persistance;
using NbaApp.Services.NbaNetClasses;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using System.Globalization;

namespace NbaApp.Services
{
    public class NbaNetService
    {
        /* Fields */
        private readonly Context _context;
        private readonly NbaNetPlayersData _jsonData;
        private readonly JsonSerializerOptions _options;

        /* Constructors */
        public NbaNetService(Context context)
        {
            _context = context;

            using WebClient client = new WebClient();
            var json = client.DownloadString("https://data.nba.net/prod/v1/2019/players.json");

            _options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            _jsonData = JsonSerializer.Deserialize<NbaNetPlayersData>(json, _options);
        }

        /* Methods */
        public async Task LoadTeams()
        {
            using WebClient client = new WebClient();
            var teamsJson = client.DownloadString("https://data.nba.net/");
            var teamsData = JsonSerializer.Deserialize<NbaNetTeamsData>(teamsJson, _options);

            var teams = teamsData.SportsContent.Teams.Teams
                .Where(x => x.IsNbaTeam == true)
                .Select(x => new Team(
                    x.Name,
                    x.NickName,
                    x.Abbreviation,
                    x.Conference == "West" ? "Western" : "Eastern",
                    x.Division,
                    x.Id.ToString()
                ));

            foreach (var team in teams)
            {
                _context.Teams.Add(team);
            }

            await _context.SaveChangesAsync();
        }

        public async Task LoadPlayerData(string firstName, string lastName)
        {
            var player = _jsonData.League.Players
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .Select(x => new PlayerInfo(
                    new Player(
                        x.FirstName,
                        x.LastName,
                        DateTime.ParseExact(x.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        float.Parse(x.HeightMetric, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToUInt16(x.WeightLbs),
                        GetTeamID(x.TeamID),
                        x.PersonID
                    ),
                    new PlayerCareerInfo(
                        x.College,
                        x.Country,
                        Convert.ToUInt16(x.JerseyNumber),
                        x.Position,
                        Convert.ToUInt16(x.Draft.Year),
                        Convert.ToUInt16(x.Draft.Round),
                        Convert.ToUInt16(x.Draft.Pick),
                        GetTeamID(x.Draft.TeamID)
                    )
                 ))
                .FirstOrDefault();

            player.Player.AddCareerInfo(player.PlayerCareerInfo);

            _context.Players.Add(player.Player);
            _context.PlayersCareerInfos.Add(player.PlayerCareerInfo);

            /* Stats */
            //LoadPlayerStats(player.NbaNetID).Wait();

            await _context.SaveChangesAsync();
        }

        public async Task LoadPlayerStats(string nbaNetID)
        {
            using WebClient client = new WebClient();
            var statsJson = client.DownloadString(string.Format("https://data.nba.net/prod/v1/2019/players/{0}_profile.json", nbaNetID));

            var statsData = JsonSerializer.Deserialize<NbaNetPlayersData>(statsJson, _options);
            await _context.SaveChangesAsync();
        }

        public Guid GetTeamID(string nbaNetId)
        {
            return _context.Teams
                .Where(x => x.NbaNetID == nbaNetId)
                .Select(x => x.ID)
                .FirstOrDefault();
        }
    }
}
