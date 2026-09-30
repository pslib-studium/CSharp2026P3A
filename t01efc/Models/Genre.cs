using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace t01efc.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public required string Text { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>(); // 1:N relationship with Game
    }
}
