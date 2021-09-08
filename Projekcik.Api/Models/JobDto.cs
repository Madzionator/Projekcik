using System;
using FluentValidation;

namespace Projekcik.Api.Models
{
    public class JobDto : JobEditDto
    {
        public Guid Id { get; set; }
    }

    public class JobEditDto 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? MinimumSalary { get; set; }
        public int? MaximumSalary { get; set; }
        public string CompanyName { get; set; }
    }

    public class JobDtoValidator : AbstractValidator<JobEditDto>
    {
        public JobDtoValidator()
        {
            RuleFor(job => job.Title).MinimumLength(5).MaximumLength(100);
            RuleFor(job => job.Description).MinimumLength(20).MaximumLength(4096);
            RuleFor(job => job.CompanyName).MaximumLength(100).NotEmpty();

            RuleFor(job => job.MaximumSalary)
                .GreaterThanOrEqualTo(0)
                .GreaterThanOrEqualTo(job => job.MinimumSalary).When(job => job.MinimumSalary != null, ApplyConditionTo.CurrentValidator);

            RuleFor(job => job.MinimumSalary)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(job => job.MaximumSalary).When(job => job.MaximumSalary  != null, ApplyConditionTo.CurrentValidator);
        }
    }
}