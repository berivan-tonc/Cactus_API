using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cactus.DataAccess.Models
{
    public class Follow
    {
        [Required, Key]
        public int id { get; set; }

        [Required]
        public int following_id { get; set; }

        [Required]
        public int followed_id { get; set; }

    }
}
