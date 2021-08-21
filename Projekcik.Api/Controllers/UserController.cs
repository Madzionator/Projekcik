using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projekcik.Core.Services;
using Projekcik.Database.Models;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : MyController
    {
        private const string ErrorMessage_CreateUser = "Nie udało się utworzyć użytkownika";
        private const string ErrorMessage_Login = "Nie udało się zalogować";

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var token = _userService.Login(dto.Login, dto.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessage_Login);
                return Error(ErrorMessage_Login);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var user = _mapper.Map<User>(userDto);
                _userService.CreateUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessage_CreateUser);
                return Error(ErrorMessage_CreateUser);
            }

            return Ok();
        }
    }
}
