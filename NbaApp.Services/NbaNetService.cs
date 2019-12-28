using NbaApp.Common.Entities;
using NbaApp.Persistance;
using NbaApp.Services.NbaNetClasses;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace NbaApp.Services
{
    public class NbaNetService
    {
        #region Fields
        private readonly Context _context;
        private readonly NbaNetPlayersData _playersData;
        private readonly NbaNetTeamsData _teamsData;
        private readonly NbaNetStandingsData _standingsData;
        private readonly JsonSerializerOptions _options;
        private IConfiguration _configuration;
        #endregion

        #region Constructors
        public NbaNetService(Context context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

            _options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            using var client = new WebClient();
            var playersJson = client.DownloadString(_configuration["NbaNetDataUrls:Players"]);
            var teamsJson = client.DownloadString(_configuration["NbaNetDataUrls:Teams"]);
            var standingsJson = client.DownloadString(_configuration["NbaNetDataUrls:Standings"]);

            _playersData = JsonSerializer.Deserialize<NbaNetPlayersData>(playersJson, _options);
            _teamsData = JsonSerializer.Deserialize<NbaNetTeamsData>(teamsJson, _options);
            _standingsData = JsonSerializer.Deserialize<NbaNetStandingsData>(standingsJson, _options);
        }
        #endregion

        #region Methods
        public async Task LoadTeams()
        {
            var teams = await Task.FromResult(_teamsData.League.Teams
                .Where(x => x.IsNbaFranchise == true)
                .Select(x => new Team(
                    x.Name,
                    x.NickName,
                    x.Abbreviation,
                    x.Conference == "West" ? "Western" : "Eastern",
                    x.Division,
                    x.Id.ToString()
                )));

            foreach (var team in teams)
            {
                _context.Teams.Add(team);

                //Stats
                var stats = await Task.FromResult(_standingsData.League.Standard.Conference.West.Concat(_standingsData.League.Standard.Conference.East)
                    .Where(x => x.TeamId == team.NbaNetID)
                    .Select(x => new TeamStats(x.TeamId, x.Wins, x.Losses, x.GamesBehind, x.ConferenceRank, x.HomeWins, x.HomeLosses, x.AwayWins, x.AwayLosses, x.WinningStreak))
                    .FirstOrDefault());

                team.AddStats(stats);

                _context.TeamStats.Add(stats);
            }

            await _context.SaveChangesAsync();
        }

        public async Task LoadPlayerDataByName(string firstName, string lastName)
        {
            var player = await Task.FromResult(_playersData.League.Players
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .Select(x => new PlayerInfo(
                    new Player(
                        x.FirstName,
                        x.LastName,
                        x.DateOfBirth,
                        x.HeightMetric,
                        x.WeightLbs,
                        GetTeamID(x.TeamID).Result,
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
                        GetTeamID(x.Draft.TeamID).Result
                    )
                 ))
                .FirstOrDefault());

            player.Player.AddCareerInfo(player.PlayerCareerInfo);

            _context.Players.Add(player.Player);
            _context.PlayerCareerInfos.Add(player.PlayerCareerInfo);

            await _context.SaveChangesAsync();

            /* Stats */
            LoadPlayerStats(player.Player.NbaNetID).Wait();
        }

        public async Task LoadPlayers()
        {
            var players = await Task.FromResult(_playersData.League.Players
                .Where(x => x.IsActive == true)
                .Select(x => new PlayerInfo(
                    new Player(
                        x.FirstName,
                        x.LastName,
                        x.DateOfBirth,
                        x.HeightMetric,
                        x.WeightLbs,
                        GetTeamID(x.TeamID).Result,
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
                        GetTeamID(x.Draft.TeamID).Result
                    )
                 )));

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

            var player = await Task.FromResult(_context.Players
                .Where(x => x.NbaNetID == nbaNetID)
                .FirstOrDefault());

            player.AddStatsInfo(stats);

            _context.PlayerStats.Add(stats);

            await _context.SaveChangesAsync();
        }

        public async Task<Guid> GetTeamID(string nbaNetId)
        {
            return await Task.FromResult(_context.Teams
                .Where(x => x.NbaNetID == nbaNetId)
                .Select(x => x.ID)
                .FirstOrDefault());
        }

        #endregion
    }
}
