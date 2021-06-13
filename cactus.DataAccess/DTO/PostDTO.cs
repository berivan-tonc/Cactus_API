using System;
using System.Collections.Generic;
using System.Text;
using cactus.DataAccess.Models;

namespace cactus.DataAccess.DTO
{
    public class PostDTO
    {
        public Post post { get; set; }

        public User user { get; set; }

        public Book book { get; set; }

        public Movie movie { get; set; }


        public Music music { get; set; }

    }
}
