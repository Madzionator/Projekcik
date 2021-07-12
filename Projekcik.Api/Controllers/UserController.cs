using System;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Projekcik.Core.Services;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ITokenManager _tokenManager;
        private readonly IHashService _hashService;

        public UserController(TodoDbContext context, ITokenManager tokenManager, IHashService hashService)
        {
            _context = context;
            _tokenManager = tokenManager;
            _hashService = hashService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _context.Users.FirstOrDefault(x => x.Login == dto.Login);
            if(user == null)
                return BadRequest();

            if (!_hashService.Check(user.Password, dto.Password))
                return BadRequest();

            var token =_tokenManager.GenerateAccessToken(user);
            return Ok(token);
        }

        [HttpPost("create")]
        public IActionResult CreateUser(UserDto user)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            _context.Users.Add(new User
            {
                Id = Guid.NewGuid(), 
                Login = user.Login, 
                Password = _hashService.Hash(user.Password),
            });
            _context.SaveChanges();

            return Ok();
        }
    }
    public class UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Login).MinimumLength(5).MaximumLength(50).NotEmpty();
            RuleFor(user => user.Password).MinimumLength(8).MaximumLength(32).NotEmpty();
        }
    }
}
