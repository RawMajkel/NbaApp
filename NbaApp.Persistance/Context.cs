using Microsoft.EntityFrameworkCore;
using NbaApp.Common.Entities;

namespace NbaApp.Persistance
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerCareerInfo> PlayersInfos { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<PlayerStats> Statistics { get; set; }
    }
}
