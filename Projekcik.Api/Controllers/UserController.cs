using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Projekcik.Api.Models;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly TokenManager _tokenManager;

        public UserController(TodoDbContext context, TokenManager tokenManager)
        {
            _context = context;
            _tokenManager = tokenManager;
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == dto.Login);
            if(user == null)
                return BadRequest();

            if (!HashPassword.Check(user.Password, dto.Password))
                return BadRequest();

            var token =_tokenManager.GenerateAccessToken(user);
            return Ok(token);
        }

        [HttpPost("create")]
        public IActionResult CreateUser(UserDto user)
        {
            _context.Users.Add(new User { Id = Guid.NewGuid(), Login = user.Login, Password = HashPassword.Hash(user.Password), });
            _context.SaveChanges();

            return Ok();
        }
    }
    public class UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
