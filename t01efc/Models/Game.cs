using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace t01efc.Models
{
    internal class Game
    {
        //public int Id { get; set; }
        public int GameId { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
