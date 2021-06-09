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
        public async Task<List<Post>> GetUserPosts(int id)
        {
            var posts = await _postService.GetUserPosts(id);
            return posts;
        }

        //Kullanıcının takip ettiği kullanıcıların attığı post listesi
        [HttpGet]
        [Route("getbyFollowedId")]
        public async Task<List<Post>> GetFollowedPosts(int id)
        {
            var posts = await _postService.GetFollowedPosts(id);
            return posts;
        }

        [HttpPost]
        public async Task<Post> Post([FromBody] Post post)
        {
            return await _postService.CreatePost(post);
        }


        [HttpPut]
        public async Task<Post> Put([FromBody] Post post)
        {
            return await _postService.UpdatePost(post);
        }

        [HttpDelete]
        public void Delete(int id)
        {
             _postService.DeletePost(id);
        }
    }
}
