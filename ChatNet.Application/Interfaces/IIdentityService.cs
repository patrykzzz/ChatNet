using ChatNet.Application.Users.Commands.LoginUser;
using ChatNet.Application.Users.Commands.RegisterUser;
using System.Threading.Tasks;

namespace ChatNet.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> LoginUser(LoginUserCommand loginModel);
        Task RegisterUser(RegisterUserCommand registrationModel);
    }
}
