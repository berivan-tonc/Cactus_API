using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using System.Linq;

namespace cactus.DataAccess.Services
{
    public class FollowService
    {
        public Task<Follow> Control(int userId, int cntrlId)
        {
            using (var dbContext = new cactusDbContext())
            {
                var query = from fl in dbContext.Follows
                            where fl.following_id == userId && fl.followed_id == cntrlId
                            select fl;
                return Task.FromResult(query?.FirstOrDefault());
            }
        }
        public async Task<Follow> CreateFollow(Follow follow)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Follows.Add(follow);
                await dbContext.SaveChangesAsync();
                return follow;
            }
        }
        public async Task DeleteFollow(int id)
        {
            using (var dbContext = new cactusDbContext())
            {
                var fl = dbContext.Follows.Find(id);
                dbContext.Follows.Remove(fl);
                await dbContext.SaveChangesAsync();
            }
        }
    }
   
}
