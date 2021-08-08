using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekcik.Core.Services;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoController> _logger;
        private readonly IUserInfo _userInfo;

        public TodoController(ILogger<TodoController> logger, TodoDbContext context, IUserInfo userInfo)
        {
            _logger = logger;
            _context = context;
            _userInfo = userInfo;
        }

        [HttpGet]
        public IActionResult GetTodoList()
        {
            var todos = _context.Todos
                .Include(x => x.User)
                .Include(x => x.Category)
                .Where(x => x.User.Id == _userInfo.Id)
                .OrderBy(x => x.Termin)
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

        [HttpGet("{id}")]
        public IActionResult GetTodo([FromRoute] int id)
        {
            var todo = _context.Todos
                .Include(x => x.User)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id && x.User.Id == _userInfo.Id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                todo.Id,
                todo.Termin,
                todo.Title,
                todo.Category
            });
        }

        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] TodoDto item)
        {
            var user = _userInfo.GetCurrentUser();

            _context.Todos.Add(new Todo
            {
                Title = item.Title,
                Termin = item.Termin.LocalDateTime,
                User = user
            });
            _context.SaveChanges();

            _logger.LogInformation($"Dodano przedmiot {item.Title}");
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditTodoItem([FromBody] TodoDto item, [FromRoute] int id)
        {
            var toEdit = _context.Todos.Include(x => x.User).FirstOrDefault(x => x.Id == id);
            if (toEdit == null || toEdit.User.Id != _userInfo.Id)
                return BadRequest();

            toEdit.Title = item.Title;
            toEdit.Termin = item.Termin.LocalDateTime;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
                return NotFound();

            var user = _userInfo.GetCurrentUser();
            if (todo.User.Id != user.Id)
                return BadRequest();

            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public class TodoDto
    {
        public string Title { get; set; }
        
        public DateTimeOffset Termin { get; set; }
    }
}