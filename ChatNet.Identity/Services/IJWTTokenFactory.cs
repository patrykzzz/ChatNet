using ChatNet.Identity.Entites;

namespace ChatNet.Identity.Services
{
    public interface IJWTTokenFactory
    {
        string GetTokenForUser(ApplicationUser user);
    }
}
