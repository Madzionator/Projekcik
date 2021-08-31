using FluentValidation;

namespace Projekcik.Api.Controllers
{
    public class LocationDto
    {
        public string Name { get; set; }
    }

    public class LocationDtoValidator : AbstractValidator<LocationDto>
    {
        public LocationDtoValidator()
        {
            RuleFor(location => location.Name).NotEmpty();
        }
    }
}