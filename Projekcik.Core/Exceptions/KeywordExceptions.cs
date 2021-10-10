using Projekcik.Infrastructure.Exceptions;

namespace Projekcik.Core.Exceptions
{
    public abstract class KeywordException : ProjekcikException
    {
        protected KeywordException(string message) : base(message)
        {
        }
    }

    public class KeywordAlreadyExistsException : KeywordException
    {
        public string Name { get; }

        public KeywordAlreadyExistsException(string name) : base($"Umiejętność '{name}' już istnieje.")
        {
            Name = name;
        }
    }

    public class KeywordNotFoundException : KeywordException
    {
        public string Name { get; }

        public KeywordNotFoundException(string name) : base($"Umiejętność '{name}' nie istnieje.")
        {
            Name = name;
        }
        public KeywordNotFoundException(int id) : base($"Umiejętność nie istnieje.") { }
    }
}