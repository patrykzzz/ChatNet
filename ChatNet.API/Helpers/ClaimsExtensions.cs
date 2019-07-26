using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatNet.API.Helpers
{
    public static class ClaimsExtensions
    {
        public static string GetUserIdFromRequest(this HttpContext context)
        {
            return context.User.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
        }
    }
}
