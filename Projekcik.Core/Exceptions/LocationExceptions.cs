using Projekcik.Infrastructure.Exceptions;

namespace Projekcik.Core.Exceptions
{
    public abstract class LocationException : ProjekcikException
    {
        protected LocationException(string message) : base(message)
        {
        }
    }

    public class LocationAlreadyExistsException : LocationException
    {
        public string Name { get; }

        public LocationAlreadyExistsException(string name) : base($"Miejsce '{name}' już istnieje.")
        {
            Name = name;
        }
    }

    public class LocationNotFoundException : LocationException
    {
        public string Name { get; }

        public LocationNotFoundException(string name) : base($"Miejsce '{name}' nie istnieje.")
        {
            Name = name;
        }
    }

    public class LocationProtectedException : LocationException
    {
        public int LocationId { get; }

        public LocationProtectedException(int locationId) : base($"Nie można zmienić tego miejsca.")
        {
            LocationId = locationId;
        }
    }
}
