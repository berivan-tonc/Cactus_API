using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using cactus.DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cactus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private MusicService _musicService;
        public MusicController()
        {
            _musicService = new MusicService();
        }

        [HttpGet]
        public async Task<List<Music>> Get()
        {
            var musics = await _musicService.GetMusic();
            return musics;
        }
        [HttpGet]
        [Route("getbyId")]
        public async Task<Music> Get(int id)
        {
            var music = await _musicService.GetMusicById(id);
            return music;
        }

        [HttpPost]
        public async Task<Music> Post([FromBody] Music music)
        {
            return await _musicService.CreateMusic(music);
        }
    }
}
