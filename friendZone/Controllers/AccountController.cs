using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using friendZone.Models;
using friendZone.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace friendZone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly FollowsService _fs;

        public AccountController(AccountService accountService, FollowsService fs)
        {
            _accountService = accountService;
            _fs = fs;
        }
        [HttpGet("follows")]
        public async Task<ActionResult<List<FollowerViewModel>>> GetFollows()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<FollowerViewModel> follows = _fs.GetFollows();
                return Ok(follows);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}