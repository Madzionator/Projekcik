using System;
using System.Collections.Generic;

namespace Projekcik.Api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Termin { get; set; }
        
        public User User { get; set; }
        
        public Category Category { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IList<Todo> Todos { get; set; }
        public IList<Category> Categories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Todo> Todos { get; set; }
        public User User { get; set; }
    }
}
