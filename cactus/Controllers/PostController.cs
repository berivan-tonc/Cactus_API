using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cactus.DataAccess.DTO;
using cactus.DataAccess.Models;
using cactus.DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cactus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private PostService _postService;
        public PostController()
        {
            _postService = new PostService();
        }

        [HttpGet]
        public async Task<List<Post>> Get()
        {
            var posts = await _postService.GetPosts();
            return posts;
        }

        [HttpGet]
        [Route("getbyId")]
        public async Task<Post> Get(int id)
        {
            var book = await _postService.GetPostById(id);
            return book;
        }

        //Kullanıcının kendi attığı post listesi
        [HttpGet]
        [Route("getbyUserId")] 
        public async Task<List<PostDTO>> GetUserPosts(int id)
        {
            var posts = await _postService.GetUserPosts(id);
            return posts;
        }

        //Kullanıcının takip ettiği kullanıcıların attığı post listesi
        [HttpGet]
        [Route("getbyFollowedId")]
        public async Task<List<PostDTO>> GetFollowedPosts(int id)
        {
            var posts = await _postService.GetFollowedPosts(id);
            return posts;
        }

        [HttpGet]
        [Route("search")]
        public async Task<List<PostDTO>> Search(char cat, int itemId)
        {
            var posts = await _postService.Search(cat, itemId);
            return posts;
        }
        [HttpGet]
        [Route("point")]
        public double GetPoint(char cat, int itemId)
        {
            var point = _postService.GetPoint(cat, itemId);
            return point;
        }

        [HttpPost]
        public async Task<Post> Post([FromBody] Post post)
        {
            post.editdate = DateTime.Now;
            return await _postService.CreatePost(post);
        }


        [HttpPut]
        public async Task<Post> Put([FromBody] Post post)
        {
            return await _postService.UpdatePost(post);
        }

        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            await _postService.DeletePost(id);
        }

        [HttpGet]
        [Route("explore")]
        public async Task<List<string>> GetWeekTopTen(char cat)
        {
            return await _postService.GetMostSharedPosts(cat);
        }
    }
}
