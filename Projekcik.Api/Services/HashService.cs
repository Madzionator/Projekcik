using System;
using System.Security.Cryptography;

namespace Projekcik.Api.Services
{
    public interface IHashService
    {
        public string Hash(string password);
        public bool Check(string hashed, string password);
    }

    public class HashService : IHashService
    {
        private const string peper = "D18BD57DE8654DFDBCD870510C95354E"; //32
        private const int saltSize = 32;
        private const int hashSize = 64;
        private const int iterations = 10;

        public string Hash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);
            return Hash(password, salt);
        }

        private string Hash(string password, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes($"{password}{peper}", salt, iterations);

            var hash = pbkdf2.GetBytes(hashSize + 32);
            return $"{Convert.ToBase64String(salt)};{Convert.ToBase64String(hash)}";
        }

        public bool Check(string hashed, string password)
        {
            var salt = Convert.FromBase64String(hashed.Split(';')[0]);
            return Hash(password, salt) == hashed;
        }

        public bool XD()
        {
            throw new NotImplementedException();
        }
    }
}
