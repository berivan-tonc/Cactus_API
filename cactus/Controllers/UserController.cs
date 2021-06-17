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
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private AuthenticateService _authenticateService;
        public UserController()
        {
            _userService = new UserService();
            _authenticateService = new AuthenticateService();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _authenticateService.Authenticate(model.email, model.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            return await _userService.CreateUser(user);
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
