using System.Threading.Tasks;
using ChatNet.API.Models;
using ChatNet.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService _identityService;

        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginWebModel webModel)
        {
            return await _identityService.GetTokenForUser(webModel);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationWebModel webModel)
        {
            await _identityService.Register(webModel);
            return Ok();
        }
    }
}
