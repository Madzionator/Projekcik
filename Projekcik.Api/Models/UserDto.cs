using FluentValidation;

namespace Projekcik.Api.Models
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Login).MinimumLength(5).MaximumLength(50).NotEmpty();
            RuleFor(user => user.Password).MinimumLength(8).MaximumLength(32).NotEmpty();
        }
    }
}