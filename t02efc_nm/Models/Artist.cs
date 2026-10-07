using System;
using System.Collections.Generic;
using System.Text;

namespace t02efc_nm.Models
{
    internal class Artist
    {
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        public required string LastName { get; set; }
        //public ICollection<Movie>? Movies { get; set; }
        public ICollection<MovieActor>? Roles { get; set; }
    }
}
