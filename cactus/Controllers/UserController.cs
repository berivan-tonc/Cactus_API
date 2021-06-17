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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            var users = await _userService.GetUsers();
            return users;
        }
        [HttpGet]
        [Route("getbyId")]
        public async Task<User> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            return user;
        }

        [HttpPut]
        public async Task<User> Put([FromBody] User user)
        {
            return await _userService.UpdateUser(user);
        }

        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            return await _userService.CreateUser(user);
        }

        [HttpGet]
        [Route("getbyFollowedId")]
        public async Task<List<User>> GetFollowedUserList(int id)
        {
            return  await _userService.GetFollowedUsersList(id);
           
        }

        [HttpGet]
        [Route("getbyFollowingId")]
        public async Task<List<User>> GetFollowingUserList(int id)
        {
            return await _userService.GetFollowingUsersList(id);
           
        }
    }
}
