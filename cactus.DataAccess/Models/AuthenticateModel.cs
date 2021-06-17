using System;
using System.ComponentModel.DataAnnotations;

namespace cactus.DataAccess.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }

}