using ChatNet.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace ChatNet.Infrastructure
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ClaimsService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            return Guid.Parse(_contextAccessor.HttpContext.User.Claims.Single(x => x.Type == "user_id").Value);
        }
    }
}
