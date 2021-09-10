using Projekcik.Infrastructure.Exceptions;

namespace Projekcik.Core.Exceptions
{
    public abstract class UserAuthException : ProjekcikException
    {
        protected UserAuthException(string message) : base(message)
        {
        }
    }

    public class UserNotFoundException : UserAuthException
    {
        public string Login { get; }

        public UserNotFoundException(string login) : base("Niepoprawne dane logowania.")
        {
            Login = login;
        }
    }

    public class UserWrongPasswordException : ProjekcikException
    {
        public string Login { get; }

        public UserWrongPasswordException(string login) : base("Niepoprawne dane logowania.")
        {
            Login = login;
        }
    }

    public class UserAlreadyExistsException : ProjekcikException
    {
        public string Login { get; }

        public UserAlreadyExistsException(string login) : base($"Użytkownik '{login}' już istnieje.")
        {
            Login = login;
        }
    }
}