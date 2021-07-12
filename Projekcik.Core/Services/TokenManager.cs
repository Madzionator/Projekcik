using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Projekcik.Database.Models;

namespace Projekcik.Core.Services
{
    internal class TokenManager : ITokenManager
    {
        private readonly string _issuer;
        private readonly string _key;

        public TokenManager(IConfiguration configuration)
        {
            _issuer = configuration["Auth:Issuer"];
            _key = configuration["Auth:Key"];
        }

        public string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {new("id", user.Id.ToString())};

            var token = new JwtSecurityToken(_issuer,
                _issuer,
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
