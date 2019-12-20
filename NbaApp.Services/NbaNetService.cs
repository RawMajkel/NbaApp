using NbaApp.Common.Entities;
using NbaApp.Persistance;
using NbaApp.Services.NbaNetClasses;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace NbaApp.Services
{
    // **********
    // API HELPER 
    //
    // https://data.nba.net/10s/prod/v3/today.json
    //
    // **********

    public class NbaNetService
    {
        /* Fields */
        private readonly Context _context;
        private readonly NbaNetPlayersData _playersData;
        private readonly NbaNetTeamsData _teamsData;
        private readonly NbaNetStandingsData _standingsData;
        private readonly JsonSerializerOptions _options;

        /* Constructors */
        public NbaNetService(Context context)
        {
            _context = context;

            _options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            using var client = new WebClient();
            var playersJson = client.DownloadString("https://data.nba.net/prod/v1/2019/players.json");
            var teamsJson = client.DownloadString("https://data.nba.net/prod/v1/2019/teams.json");
            var standingsJson = client.DownloadString("https://data.nba.net/prod//v1/current/standings_conference.json");

            _playersData = JsonSerializer.Deserialize<NbaNetPlayersData>(playersJson, _options);
            _teamsData = JsonSerializer.Deserialize<NbaNetTeamsData>(teamsJson, _options);
            _standingsData = JsonSerializer.Deserialize<NbaNetStandingsData>(standingsJson, _options);
        }

        /* Methods */
        public async Task LoadTeams()
        {
            var teams = _teamsData.League.Teams
                .Where(x => x.IsNbaFranchise == true)
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

                //Stats

            }

            await _context.SaveChangesAsync();
        }

        public async Task LoadPlayerDataByName(string firstName, string lastName)
        {
            var player = _playersData.League.Players
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .Select(x => new PlayerInfo(
                    new Player(
                        x.FirstName,
                        x.LastName,
                        x.DateOfBirth,
                        x.HeightMetric,
                        x.WeightLbs,
                        GetTeamID(x.TeamID),
                        x.PersonID
                    ),
                    new PlayerCareerInfo(
                        x.College,
                        x.Country,
                        x.JerseyNumber,
                        x.Position,
                        x.Draft.Year,
                        x.Draft.Round,
                        x.Draft.Pick,
                        x.NbaDebutYear,
                        GetTeamID(x.Draft.TeamID)
                    )
                 ))
                .FirstOrDefault();

            player.Player.AddCareerInfo(player.PlayerCareerInfo);

            _context.Players.Add(player.Player);
            _context.PlayerCareerInfos.Add(player.PlayerCareerInfo);

            await _context.SaveChangesAsync();

            /* Stats */
            LoadPlayerStats(player.Player.NbaNetID).Wait();
        }

        public async Task LoadPlayers()
        {
            var players = _playersData.League.Players
                .Where(x => x.IsActive == true)
                .Select(x => new PlayerInfo(
                    new Player(
                        x.FirstName,
                        x.LastName,
                        x.DateOfBirth,
                        x.HeightMetric,
                        x.WeightLbs,
                        GetTeamID(x.TeamID),
                        x.PersonID
                    ),
                    new PlayerCareerInfo(
                        x.College,
                        x.Country,
                        x.JerseyNumber,
                        x.Position,
                        x.Draft.Year,
                        x.Draft.Round,
                        x.Draft.Pick,
                        x.NbaDebutYear,
                        GetTeamID(x.Draft.TeamID)
                    )
                 ));

            foreach (var player in players)
            {
                player.Player.AddCareerInfo(player.PlayerCareerInfo);

                /* Stats */
                using WebClient client = new WebClient();
                var statsJson = client.DownloadString(string.Format("https://data.nba.net/prod/v1/2019/players/{0}_profile.json", player.Player.NbaNetID));
                var statsData = JsonSerializer.Deserialize<NbaNetStatsData>(statsJson, _options);

                var stats = new PlayerStats(
                    statsData.League.Standard.Stats.Latest.GamesPlayed,
                    statsData.League.Standard.Stats.Latest.GamesStarted,
                    statsData.League.Standard.Stats.Latest.Minutes,
                    statsData.League.Standard.Stats.Latest.FGA,
                    statsData.League.Standard.Stats.Latest.FGM,
                    statsData.League.Standard.Stats.Latest.TPA,
                    statsData.League.Standard.Stats.Latest.TPM,
                    statsData.League.Standard.Stats.Latest.FTA,
                    statsData.League.Standard.Stats.Latest.FTM,
                    statsData.League.Standard.Stats.Latest.OffReb,
                    statsData.League.Standard.Stats.Latest.DefReb,
                    statsData.League.Standard.Stats.Latest.Assists,
                    statsData.League.Standard.Stats.Latest.Blocks,
                    statsData.League.Standard.Stats.Latest.Steals,
                    statsData.League.Standard.Stats.Latest.Fouls,
                    statsData.League.Standard.Stats.Latest.Turnovers);


                player.Player.AddStatsInfo(stats);

                _context.Players.Add(player.Player);
                _context.PlayerCareerInfos.Add(player.PlayerCareerInfo);
                _context.PlayerStats.Add(stats);

                await _context.SaveChangesAsync();
            }
        }

        public async Task LoadPlayerStats(string nbaNetID)
        {
            using WebClient client = new WebClient();
            var statsJson = client.DownloadString(string.Format("https://data.nba.net/prod/v1/2019/players/{0}_profile.json", nbaNetID));
            var statsData = JsonSerializer.Deserialize<NbaNetStatsData>(statsJson, _options);

            var stats = new PlayerStats(
                statsData.League.Standard.Stats.Latest.GamesPlayed,
                statsData.League.Standard.Stats.Latest.GamesStarted,
                statsData.League.Standard.Stats.Latest.Minutes,
                statsData.League.Standard.Stats.Latest.FGA,
                statsData.League.Standard.Stats.Latest.FGM,
                statsData.League.Standard.Stats.Latest.TPA,
                statsData.League.Standard.Stats.Latest.TPM,
                statsData.League.Standard.Stats.Latest.FTA,
                statsData.League.Standard.Stats.Latest.FTM,
                statsData.League.Standard.Stats.Latest.OffReb,
                statsData.League.Standard.Stats.Latest.DefReb,
                statsData.League.Standard.Stats.Latest.Assists,
                statsData.League.Standard.Stats.Latest.Blocks,
                statsData.League.Standard.Stats.Latest.Steals,
                statsData.League.Standard.Stats.Latest.Fouls,
                statsData.League.Standard.Stats.Latest.Turnovers);

            var player = _context.Players
                .Where(x => x.NbaNetID == nbaNetID)
                .FirstOrDefault();

            player.AddStatsInfo(stats);

            _context.PlayerStats.Add(stats);

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
