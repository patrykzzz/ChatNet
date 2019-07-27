using ChatNet.Application.Users.Commands.LoginUser;
using ChatNet.Application.Users.Commands.RegisterUser;
using ChatNet.Identity.Entites;
using ChatNet.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ChatNet.Identity.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJWTTokenFactory _tokenFactory;

        public UsersController(ILogger<UsersController> logger, UserManager<ApplicationUser> userManager, IJWTTokenFactory tokenFactory)
        {
            _logger = logger;
            _userManager = userManager;
            _tokenFactory = tokenFactory;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(command.Email);

                if (user == null)
                {
                    return BadRequest();
                }

                var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, command.Password);

                if (!isPasswordCorrect)
                {
                    return BadRequest();
                }

                return Ok(_tokenFactory.GetTokenForUser(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when logging a user in.");
                return BadRequest();
            }
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var user = new ApplicationUser
                {
                    Email = command.Email,
                    UserName = command.UserName,
                    FirstName = command.FirstName,
                    LastName = command.LastName
                };

                var result = await _userManager.CreateAsync(user, command.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when registering user.");
                return BadRequest();
            }

        }
    }
}
