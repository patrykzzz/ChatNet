using ChatNet.Application.Users.Commands.LoginUser;
using ChatNet.Application.Users.Commands.RegisterUser;
using ChatNet.Application.Users.Models;
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
        public async Task<ActionResult<UserTokenDto>> Login([FromBody] LoginUserCommand command)
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

                var model = new UserTokenDto
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName,
                    Token = _tokenFactory.GetTokenForUser(user)
                };

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when logging a user in.");
                return BadRequest();
            }
        }

        [HttpPost("/register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUserCommand command)
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

                var createdUser = await _userManager.FindByNameAsync(user.UserName);

                if (result.Succeeded)
                {
                    return Ok(new UserDto
                    {
                        Id = createdUser.Id,
                        Email = createdUser.Email,
                        FirstName = createdUser.FirstName,
                        LastName = createdUser.LastName,
                        Username = createdUser.UserName
                    });
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
