using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using friendZone.Models;
using friendZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace friendZone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowsController : ControllerBase
    {
        private readonly FollowsService _fs;

        public FollowsController(FollowsService fs)
        {
            _fs = fs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Follow>> Create([FromBody] Follow follow)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                follow.FollowerId = userInfo.Id;
                Follow newFollow = _fs.Create(follow);
                return Ok(newFollow);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _fs.Delete(id, userInfo.Id);
                return Ok("Follow removed");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}