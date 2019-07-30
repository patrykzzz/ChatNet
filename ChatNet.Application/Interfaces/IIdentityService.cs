using ChatNet.Application.Users.Commands.LoginUser;
using ChatNet.Application.Users.Commands.RegisterUser;
using ChatNet.Application.Users.Models;
using System.Threading.Tasks;

namespace ChatNet.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<UserTokenDto> LoginUser(LoginUserCommand loginModel);
        Task<UserDto> RegisterUser(RegisterUserCommand registrationModel);
    }
}
