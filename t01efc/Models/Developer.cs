using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace t01efc.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<Game>? Games { get; set; } // N:N 
    }
}
