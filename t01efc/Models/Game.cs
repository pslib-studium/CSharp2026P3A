using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace t01efc.Models
{
    public class Game
    {
        //public int Id { get; set; }
        public int GameId { get; set; }

        [Required]
        public required string Name { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; } // N:1 relationship with Genre

        public ICollection<Developer>? Developers { get; set; } // N:M
    }
}
