using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace cactus.DataAccess.Services
{
    public class MovieService
    {
        public async Task<List<Movie>> GetMovies()
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Movies.ToListAsync();
            }
        }
        public async Task<Movie> GetMovieById(int movieId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Movies.FindAsync(movieId);
            }
        }
        public async Task<Movie> CreateMovie(Movie movie)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Movies.Add(movie);
                await dbContext.SaveChangesAsync();
                return movie;
            }
        }
    }
}
