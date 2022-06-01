using friendZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace friendZone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController
    {
        private readonly ProfilesService _ps;

        public ProfilesController(ProfilesService ps)
        {
            _ps = ps;
        }


    }
}