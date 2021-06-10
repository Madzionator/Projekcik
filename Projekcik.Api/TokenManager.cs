using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;
using Projekcik.Api.Models;

namespace Projekcik.Api
{
    public class TokenManager
    {
        private readonly IConfiguration _configuration;

        //poprawke ci zrobie do kodu gościa XD 
        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user)
        {
            var secret = _configuration["Auth:secret"];

            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Encoding.ASCII.GetBytes(secret))
                //.AddClaim("exp", DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds())
                //.AddClaim("userId", user.Id)
                .Encode();
        }
    }
}
