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
            var teamsJson = client.DownloadString("https://data.nba.net/prod/v1/2019/teams.json");
            var teamsData = JsonSerializer.Deserialize<NbaNetTeamsData>(teamsJson, _options);

            var teams = teamsData.League.Teams
                .Where(x => x.IsNbaFranchise == true)
                .Select(x => new Team(
                    x.Name,
                    x.NickName,
                    x.Abbreviation,
                    x.Conference == "West" ? "Western" : "Eastern",
                    x.Division,
                    x.Id
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
            _context.PlayersInfos.Add(player.PlayerCareerInfo);

            await _context.SaveChangesAsync();

            /* Stats */
            LoadPlayerStats(player.Player.NbaNetID).Wait();
        }

        public async Task LoadPlayerStats(string nbaNetID)
        {
            using WebClient client = new WebClient();
            var statsJson = client.DownloadString(string.Format("https://data.nba.net/prod/v1/2019/players/{0}_profile.json", nbaNetID));
            var statsData = JsonSerializer.Deserialize<NbaNetStatsData>(statsJson, _options);

            var stats = new PlayerStats(
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.GamesPlayed),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.GamesStarted),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.Minutes),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.FGA),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.FGM),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.TPA),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.TPM),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.FTA),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.FTM),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.OffReb),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.DefReb),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.Assists),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.Blocks),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.Steals),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.Fouls),
                Convert.ToInt32(statsData.League.Standard.Stats.Latest.Turnovers));

            var player = _context.Players
                .Where(x => x.NbaNetID == nbaNetID)
                .FirstOrDefault();

            player.AddStatsInfo(stats);

            _context.Statistics.Add(stats);

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
