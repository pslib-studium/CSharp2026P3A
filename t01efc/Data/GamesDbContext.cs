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
        }
    }
}

// NuGet Package Console Commands:
// PM> Add-Migration Initial
// PM> Update-Database

