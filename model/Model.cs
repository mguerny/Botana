using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Botana
{
    public class RPGContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Sheet> Sheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rpg.db");
        }
    }

    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameMaster { get; set; }

        public ICollection<Player> GamePlayer { get; set; }
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public Sheet Sheet { get; set; }
    }

    public class Sheet
    {
        public int SheetId { get; set; }
        public ICollection<Stats> PlayerStats { get; set; }
    }

    public class Stats
    {
        public int StatsId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}