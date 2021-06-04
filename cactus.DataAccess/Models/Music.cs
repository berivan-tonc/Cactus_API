using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cactus.DataAccess.Models
{
    public class Music
    {
        [Required, Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string singer { get; set; }
    }
}
