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

        public async Task<List<Post>> Search(int cat, int itemId)
        {
            using (var dbContext = new cactusDbContext())
            {
                var posts = await (from p in dbContext.Posts
                                   join b in dbContext.Books on  p.book_id equals b.id
                                   join mv in dbContext.Movies on p.movie_id equals mv.id
                                   join ms in dbContext.Music on p.music_id equals ms.id
                                   where p.status == true && p.category == cat && (p.book_id != null && p.book_id == itemId) || (p.movie_id != null && p.movie_id == itemId) || (p.music_id != null && p.music_id == itemId)
                                   select p).ToListAsync();

                return posts.OrderBy(x => x.editdate).ToList();
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
                var posts = await dbContext.Posts.Where(u => u.user_id == UserId).ToListAsync();
                return posts.OrderBy(x => x.editdate).Reverse().ToList();
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

        public async Task DeletePost(int id)
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
                              join f in dbContext.Follows on p.user_id equals f.followed_id
                              where f.following_id == UserId
                              select p).ToListAsync();

                return posts.OrderBy(x => x.editdate).Reverse().ToList();

            }
        }
    }
}
