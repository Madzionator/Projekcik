using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekcik.Api.Models;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly TodoDbContext _context;
        public CategoryController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Category> All()
        {
            var categoryList = _context.Categories;
            return categoryList;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCategory(CategoryDto category)
        {
            _context.Categories.Add(new Category { Name = category.Name });
            _context.SaveChanges();

            return Ok();
        }

    }

    public class CategoryDto
    {
        public string Name { get; set; } 
    }
}
