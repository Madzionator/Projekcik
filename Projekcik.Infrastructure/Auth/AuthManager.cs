using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Projekcik.Infrastructure.Api;

namespace Projekcik.Infrastructure.Auth
{
    public sealed class AuthManager : IAuthManager
    {
        private readonly AuthOptions _options;
        private readonly string _issuer;

        public AuthManager(AuthOptions options)
        {
            var issuerSigningKey = options.Key;
            if (issuerSigningKey is null)
            {
                throw new InvalidOperationException("Issuer signing key not set.");
            }

            _options = options;
            _issuer = options.Issuer;
        }

        public JsonWebToken CreateToken(Guid userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> { new("id", userId.ToString()) };
            var expires = DateTime.Now.Add(_options.Expiry);

            var token = new JwtSecurityToken(_issuer,
                _issuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return new JsonWebToken
            {
                AccessToken = tokenValue,
                Expiry = new DateTimeOffset(expires).ToUnixTimeMilliseconds(),
                UserId = userId
            };
        }
    }
}