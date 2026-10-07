using System;
using System.Collections.Generic;
using System.Text;

namespace t02efc_nm.Models
{
    internal class Movie
    {
        public int MovieId { get; set; }
        public required string Name { get; set; }
        // public ICollection<Artist>? Artists { get; set; }
        public ICollection<MovieActor>? Roles { get; set; }
    }
}
