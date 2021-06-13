using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Projekcik.Api
{
    public class HashPassword
    {
        private const string peper = "D18BD57DE8654DFDBCD870510C95354E"; //32
        private const int saltSize = 32;
        private const int hashSize = 64;
        private const int iterations = 10;

        public static string Hash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);
            return Hash(password, salt);
        }

        private static string Hash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes($"{password}{peper}", salt, iterations))
            {
                var hash = pbkdf2.GetBytes(hashSize + 32);
                return $"{Convert.ToBase64String(salt)};{Convert.ToBase64String(hash)}";
            }
        }

        public static bool Check(string hashed, string password)
        {
            var salt = Convert.FromBase64String(hashed.Split(';')[0]);
            return Hash(password, salt) == hashed;
        }
    }
}
