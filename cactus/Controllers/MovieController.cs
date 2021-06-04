using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using cactus.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace cactus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController()
        {
            _movieService = new MovieService();
        }

        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            var movies = await _movieService.GetMovies();
            return movies;
        }
        [HttpGet]
        [Route("getbyId")]
        public async Task<Movie> Get(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            return movie;
        }

        [HttpPost]
        public async Task<Movie> Post([FromBody] Movie movie)
        {
            return await _movieService.CreateMovie(movie);
        }
    }
}
