using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace t02efc_nm.Models
{
    [PrimaryKey(nameof(MovieId), nameof(ArtistId), nameof(RoleName))] // composite primary key for the pivot table
    internal class MovieActor // pivot table for many-to-many relationship between Movie and Artist
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public required string RoleName { get; set; }
    }
}
