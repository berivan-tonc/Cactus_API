using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cactus.DataAccess.Models
{
    public class Movie
    {
        [Required, Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public int year { get; set; }
    }
}
