using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cactus.DataAccess.Models
{
    public class User
    {

        [Required, Key]
        public int id { get; set; }

        [Required, StringLength(20)]
        public string firstname { get; set; }

        [Required, StringLength(20)]
        public string lastname { get; set; }

        [Required]
        public bool gender { get; set; }

        [Required]
        public DateTime birthday { get; set; }

        public string picture { get; set; }

        [Required, StringLength(255)]
        public string email { get; set; }

        [Required, StringLength(30)]
        public string password { get; set; }
    }
}
