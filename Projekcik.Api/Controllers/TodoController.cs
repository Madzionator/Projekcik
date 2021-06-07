using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekcik.Api.Models;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger, TodoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            var todos = _context.Todos
                .Include(x => x.User)
                .Include(x => x.Category)
                .Select(x => new
                {
                    x.Id,
                    x.Title,
                    x.Termin,
                    User = new { x.User.Id, x.User.Login },
                });
            //dlatego to rozwiązanie ^ jest dobre na bardzo proste rzeczy XD  bo ten category to null
            return Ok(todos);
        }

        [HttpPost]
        public IActionResult CreateTodoItem(TodoDto item, Guid userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return BadRequest();

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
        public IActionResult EditTodoItem(TodoDto item, int id)
        {
            var toEdit = _context.Todos.Find(id);
            if (toEdit == null)
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