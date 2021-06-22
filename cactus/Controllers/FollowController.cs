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
    public class FollowController
    {
        private FollowService _followService;
        public FollowController()
        {
            _followService = new FollowService();
        }


        [HttpGet("{userId}/{cntrlId}")]
        public async Task<Follow> Control(int userId, int cntrlId)
        {
            var evnt = await _followService.Control(userId, cntrlId);
            return evnt;
        }

        [HttpPost]
        public async Task<Follow> Post([FromBody] Follow follow)
        {
            return await _followService.CreateFollow(follow);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _followService.DeleteFollow(id);
        }
    }
}
