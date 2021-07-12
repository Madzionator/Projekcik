using System;
using System.Collections.Generic;

namespace Projekcik.Database.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IList<Todo> Todos { get; set; }
        public IList<Category> Categories { get; set; }
    }
}