using System.Collections.Generic;

namespace Projekcik.Database.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Todo> Todos { get; set; }

        public User User { get; set; }
    }
}