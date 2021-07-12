using System;

namespace Projekcik.Database.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Termin { get; set; }
        
        public User User { get; set; }
        
        public Category Category { get; set; }
    }
}
