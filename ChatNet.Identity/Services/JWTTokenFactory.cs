using ChatNet.Identity.Entites;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatNet.Identity.Services
{
    internal class JWTTokenFactory : IJWTTokenFactory
    {
        private readonly IConfiguration _configuration;

        public JWTTokenFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetTokenForUser(ApplicationUser user)
        {
            var claims = new Claim[]
            {
                new Claim("user_id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("first_name", user.FirstName),
                new Claim("last_name", user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Identity:JWTSigningKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Identity:JWTIssuer"],
                _configuration["Identity:JWTAudience"],
                claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
