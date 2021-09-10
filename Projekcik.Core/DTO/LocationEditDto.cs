using FluentValidation;

namespace Projekcik.Core.DTO
{
    public class LocationDto : LocationEditDto
    {
        public int Id { get; set; }
    }

    public class LocationEditDto
    {
        public string Name { get; set; }
    }

    public class LocationEditDtoValidator : AbstractValidator<LocationEditDto>
    {
        public LocationEditDtoValidator()
        {
            RuleFor(location => location.Name).NotEmpty().MaximumLength(100);
        }
    }
}