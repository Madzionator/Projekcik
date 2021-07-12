using FluentValidation;
using Projekcik.Api.Controllers;

namespace Projekcik.Api.Models
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Login).MinimumLength(5).MaximumLength(50).NotEmpty();
            RuleFor(user => user.Password).MinimumLength(8).MaximumLength(32).NotEmpty();
        }
    }
}
