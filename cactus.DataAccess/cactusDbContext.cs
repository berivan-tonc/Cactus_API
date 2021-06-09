using System;
using System.Collections.Generic;
using System.Text;
using cactus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace cactus.DataAccess
{
    public class cactusDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Cactus;Username=postgres;Password=post");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }
    }
}
