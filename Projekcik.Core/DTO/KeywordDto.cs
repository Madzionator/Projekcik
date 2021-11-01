using System.Diagnostics;
using FluentValidation;

namespace Projekcik.Core.DTO
{
    public class KeywordDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public override string ToString() => $"{Id}: {Name}";
    }
    public class KeywordEditDto
    {
        public string Name { get; set; }
    }

    public class KeywordStatsDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int CandidateCount { get; set; }
    }

    public class KeywordEditDtoValidator : AbstractValidator<LocationEditDto>
    {
        public KeywordEditDtoValidator()
        {
            RuleFor(location => location.Name).NotEmpty().MaximumLength(64).MinimumLength(1);
        }
    }
}