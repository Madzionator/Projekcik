using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Projekcik.Api.Models;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TodoDbContext _context;
        public UserController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> All()
        {
            var usersList = _context.Users;
            return usersList;
        }

        [HttpPost]
        public IActionResult CreateUser(UserDto user)
        {
            _context.Users.Add(new User { Id = Guid.NewGuid(), Login = user.Login, Password = user.Password, });
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
