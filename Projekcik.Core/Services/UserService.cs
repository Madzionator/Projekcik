using System.Linq;
using AutoMapper;
using Projekcik.Core.DTO;
using Projekcik.Core.Exceptions;
using Projekcik.Core.Utils;
using Projekcik.Database;
using Projekcik.Database.Models;
using Projekcik.Infrastructure.Api;

namespace Projekcik.Core.Services
{
    public interface IUserService
    {
        void CreateUser(UserDto user);
        string Login(string dtoLogin, string dtoPassword);
    }

    internal class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IHashService _hashService;
        private readonly IAuthManager _authManager;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IHashService hashService, IAuthManager authManager, IMapper mapper)
        {
            _context = context;
            _hashService = hashService;
            _authManager = authManager;
            _mapper = mapper;
        }

        public void CreateUser(UserDto dto)
        {
            if (_context.Users.Any(x => x.Login == dto.Login))
            {
                throw new UserAlreadyExistsException(dto.Login);
            }

            var user = _mapper.Map<User>(dto);
            user.Password = _hashService.Hash(dto.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public string Login(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login);
            if (user is null)
            {
                throw new UserNotFoundException(login);
            }

            if (!_hashService.Check(user.Password, password))
            {
                throw new UserWrongPasswordException(login);
            }

            var token = _authManager.CreateToken(user.Id);
            return token.AccessToken;
        }
    }
}