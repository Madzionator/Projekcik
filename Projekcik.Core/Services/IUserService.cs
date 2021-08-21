using System;
using System.Linq;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Core.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        string Login(string dtoLogin, string dtoPassword);
    }

    internal class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IHashService _hashService;
        private readonly ITokenManager _tokenManager;

        public UserService(DataContext context, IHashService hashService, ITokenManager tokenManager)
        {
            _context = context;
            _hashService = hashService;
            _tokenManager = tokenManager;
        }

        public void CreateUser(User user)
        {
            if (_context.Users.Any(x => x.Login == user.Login))
            {
                throw new Exception("User already exists");
            }

            user.Password = _hashService.Hash(user.Password);
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public string Login(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!_hashService.Check(user.Password, password))
            {
                throw new Exception("Wrong user password");
            }

            return _tokenManager.GenerateAccessToken(user);
        }
    }
}
