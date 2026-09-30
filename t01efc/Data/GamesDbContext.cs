using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using t01efc.Models;

namespace t01efc.Data
{
    public class GamesDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }

        private string _connectionString = @"Data Source=games.sqlite";

        public GamesDbContext()
        {
        }

        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options)
        {
        }

        public GamesDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Game>().HasKey(g => g.GameId);
            //modelBuilder.Entity<Game>().Property(g => g.Name).IsRequired();
            // seed
            // je potřeba to seedovat včetně ID, protože jinak by to nefungovalo, protože by se to snažilo vložit s ID 0 a to by nebylo unikátní
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Text = "Action" },
                new Genre { GenreId = 2, Text = "RPG" },
                new Genre { GenreId = 3, Text = "Adventure" },
                new Genre { GenreId = 4, Text = "Strategy" },
                new Genre { GenreId = 5, Text = "Simulation" }
            );
            modelBuilder.Entity<Developer>().HasData(
                new Developer { DeveloperId = 1, Name = "CD Projekt Red" },
                new Developer { DeveloperId = 2, Name = "Bethesda Game Studios" },
                new Developer { DeveloperId = 3, Name = "Rockstar Games" },
                new Developer { DeveloperId = 4, Name = "Valve Corporation" },
                new Developer { DeveloperId = 5, Name = "Ubisoft" }
            );
        }
    }
}

// NuGet Package Console Commands:
// PM> Add-Migration Initial
// PM> Update-Database

