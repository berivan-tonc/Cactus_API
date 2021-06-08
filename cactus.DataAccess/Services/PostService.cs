using cactus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cactus.DataAccess.Services
{
    public class PostService
    {
        public async Task<List<Post>> GetPosts()
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Posts.ToListAsync();
            }
        }

        public async Task<Post> GetPostById(int PostId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Posts.FindAsync(PostId);
            }
        }

        public async Task<List<Post>> GetUserPosts(int UserId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Posts.Where(u => u.user_id == UserId).ToListAsync();
            }
        }

        public async Task<Post> CreatePost(Post post)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Posts.Add(post);
                await dbContext.SaveChangesAsync();
                return post;
            }
        }

        public async void DeletePost(int id)
        {
            using (var dbContext = new cactusDbContext())
            {
                var deletePost = await GetPostById(id);
                dbContext.Posts.Remove(deletePost);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Post> UpdatePost(Post post)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Posts.Update(post);
                await dbContext.SaveChangesAsync();
                return post;
            }
        }

        public async Task<List<Post>> GetFollowedPosts(int UserId)
        {
            using (var dbContext = new cactusDbContext())
            {
                var posts = await (from p in dbContext.Posts
                              join f in dbContext.Follows on p.user_id equals f.followied_id
                              where f.following_id == UserId
                              select p).ToListAsync();

                return posts.OrderBy(x => x.editdate).ToList();

            }
        }
    }
}
