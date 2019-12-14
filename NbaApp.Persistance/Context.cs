using Microsoft.EntityFrameworkCore;
using NbaApp.Common.Entities;
using System;

namespace NbaApp.Persistance
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }
}
