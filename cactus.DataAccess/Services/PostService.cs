﻿using cactus.DataAccess.DTO;
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

        public async Task<List<PostDTO>> Search(char cat, int itemId)
        {
            using (var dbContext = new cactusDbContext())
            {
                var posts = await (from p in dbContext.Posts
                                   join u in dbContext.Users on p.user_id equals u.id
                                   join b in dbContext.Books on new { Book = p.book_id } equals new { Book = (int?)b.id } into btemp
                                   from bk in btemp.DefaultIfEmpty()
                                   join mv in dbContext.Movies on new { Movie = p.movie_id } equals new { Movie = (int?)mv.id } into motemp
                                   from mov in motemp.DefaultIfEmpty()
                                   join mu in dbContext.Music on new { Music = p.music_id } equals new { Music = (int?)mu.id } into mutemp
                                   from mus in mutemp.DefaultIfEmpty()
                                   where (p.status == true) && (p.category == cat) && ((p.book_id != null && p.book_id == itemId) || (p.movie_id != null && p.movie_id == itemId) || (p.music_id != null && p.music_id == itemId))
                                   select new PostDTO { post=p,music=mus,book= bk, movie=mov, user=u}).ToListAsync();


                return posts.OrderBy(x => x.post.editdate).Reverse().ToList();
            }
        }

        public async Task<Post> GetPostById(int PostId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Posts.FindAsync(PostId);
            }
        }

        public async Task<List<PostDTO>> GetUserPosts(int UserId)
        {
            using (var dbContext = new cactusDbContext())
            {
                var posts = await (from p in dbContext.Posts
                                   join u in dbContext.Users on p.user_id equals u.id
                                   join b in dbContext.Books on new { Book = p.book_id } equals new { Book = (int?)b.id } into btemp
                                   from bk in btemp.DefaultIfEmpty()
                                   join mv in dbContext.Movies on new { Movie = p.movie_id } equals new { Movie = (int?)mv.id } into motemp
                                   from mov in motemp.DefaultIfEmpty()
                                   join mu in dbContext.Music on new { Music = p.music_id } equals new { Music = (int?)mu.id } into mutemp
                                   from mus in mutemp.DefaultIfEmpty()
                                   where (p.status == true) && p.user_id == UserId
                                   select new PostDTO { post = p, music = mus, book = bk, movie = mov, user = u }).ToListAsync();


                return posts.OrderBy(x => x.post.editdate).Reverse().ToList();
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

        public async Task<List<PostDTO>> GetFollowedPosts(int UserId)
        {
            using (var dbContext = new cactusDbContext())
            {
                var posts = await (from p in dbContext.Posts
                                   join u in dbContext.Users on p.user_id equals u.id
                                   join b in dbContext.Books on new { Book = p.book_id } equals new { Book = (int?)b.id } into btemp
                                   from bk in btemp.DefaultIfEmpty()
                                   join mv in dbContext.Movies on new { Movie = p.movie_id } equals new { Movie = (int?)mv.id } into motemp
                                   from mov in motemp.DefaultIfEmpty()
                                   join mu in dbContext.Music on new { Music = p.music_id } equals new { Music = (int?)mu.id } into mutemp
                                   from mus in mutemp.DefaultIfEmpty()
                                   join f in dbContext.Follows on p.user_id equals f.followed_id
                                   where (p.status == true) && f.following_id == UserId
                                   select new PostDTO { post = p, music = mus, book = bk, movie = mov, user = u }).ToListAsync();


                return posts.OrderBy(x => x.post.editdate).Reverse().ToList();

            }
        }
    }
}
