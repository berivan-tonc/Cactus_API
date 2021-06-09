using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cactus.DataAccess.Models
{
    public class Post
    {
        [Required, Key]
        public int id { get; set; }

        [Required]
        public char category { get; set; }

        [Required]
        public int user_id { get; set; }

        
        public int? book_id { get; set; }

        
        public int? music_id { get; set; }

      
        public int? movie_id { get; set; }

        [Required]
        public bool status { get; set; }

        [Required]
        public string comment { get; set; }

        [Required]
        public int point { get; set; }

        [Required]
        public DateTime editdate { get; set; }
    }
}
