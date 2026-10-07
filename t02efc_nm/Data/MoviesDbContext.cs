using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using t02efc_nm.Models;

namespace t02efc_nm.Data
{
    internal class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=movies.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Movie>().HasKey(m => m.Movieid);
            modelBuilder.Entity<Artist>().HasKey(a => a.ArtistId);
            */
            //modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.MovieId, ma.ArtistId, ma.RoleName });
            int inception = 1;
            int leonardo = 1;

            modelBuilder.Entity<Movie>().HasData(new Movie 
            { 
                MovieId = inception, 
                Name = "Inception" 
            });
            modelBuilder.Entity<Artist>().HasData(new Artist 
            { 
                ArtistId = leonardo, 
                FirstName = "Leonardo", 
                LastName = "DiCaprio"
            });
            modelBuilder.Entity<MovieActor>().HasData(new MovieActor
            {
                MovieId = inception,
                ArtistId = leonardo,
                RoleName = "Cobb"
            });
        }
    }
}
