using FluentValidation;

namespace Projekcik.Api.Models
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