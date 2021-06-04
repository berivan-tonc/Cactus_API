using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace cactus.DataAccess.Services
{
    public class MusicService
    {
        public async Task<List<Music>> GetMusic()
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Music.ToListAsync();
            }
        }
        public async Task<Music> GetMusicById(int musicId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Music.FindAsync(musicId);
            }
        }
        public async Task<Music> CreateMusic(Music music)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Music.Add(music);
                await dbContext.SaveChangesAsync();
                return music;
            }
        }
    }
}
