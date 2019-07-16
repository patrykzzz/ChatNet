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
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return await _identityService.GetTokenForUser(webModel);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationWebModel webModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _identityService.Register(webModel);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
