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
        public async Task<ActionResult<AuthorizationTokenWebModel>> Login([FromBody] UserLoginWebModel webModel)
        {
            var token = await _identityService.GetTokenForUser(webModel);

            return Ok(new AuthorizationTokenWebModel
            {
                Token = token
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationWebModel webModel)
        {
            await _identityService.Register(webModel);
            return Ok();
        }
    }
}
