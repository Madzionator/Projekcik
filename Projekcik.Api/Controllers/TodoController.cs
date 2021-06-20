using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekcik.Api.Models;
using Projekcik.Api.Services;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoController> _logger;
        private readonly UserInfo _userInfo;

        public TodoController(ILogger<TodoController> logger, TodoDbContext context, UserInfo userInfo)
        {
            _logger = logger;
            _context = context;
            _userInfo = userInfo;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            var todos = _context.Todos
                .Include(x => x.User)
                .Include(x => x.Category)
                .Where(x => x.User.Id == _userInfo.Id)
                .ToList();

            return Ok(todos.Select(x =>
                new
                {
                    x.Id,
                    x.Termin,
                    x.Title,
                    x.Category
                })
            );
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateTodoItem(TodoDto item)
        {
            var user = _userInfo.GetCurrentUser();

            _context.Todos.Add(new Todo
            {
                Title = item.Title,
                Termin = item.Termin,
                User = user
            });
            _context.SaveChanges();

            _logger.LogInformation($"dodano przedmiot {item.Title}");
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult EditTodoItem(TodoDto item, int id)
        {
            var toEdit = _context.Todos.Include(x => x.User).FirstOrDefault(x => x.Id == id);
            if (toEdit == null || toEdit.User.Id != _userInfo.Id)
                return BadRequest();

            toEdit.Title = item.Title;
            toEdit.Termin = item.Termin;

            _context.SaveChanges();
            return NoContent();
        }
    }

    public class TodoDto
    {
        public string Title { get; set; }
        public DateTime Termin { get; set; }
    }

}