using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Linq;

namespace ChatNet.API.Helpers
{
    public static class ClaimsExtensions
    {
        public static Guid GetUserIdFromRequest(this HttpContext context)
        {
            return new Guid(context.User.Claims.Single(x => x.Type == "user_id").Value);
        }
    }
}
