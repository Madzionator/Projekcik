using System;
using System.Collections.Generic;
using FluentValidation;
using Projekcik.Database.Models;

namespace Projekcik.Core.DTO
{
    public class CandidateDto
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CvPath { get; set; }
        public string Comment { get; set; }
        public ICollection<KeywordDto> Keywords { get; set; }
    }

    public class CandidateDtoValidator : AbstractValidator<CandidateDto>
    {
        public CandidateDtoValidator()
        {
            RuleFor(candidate => candidate.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(candidate => candidate.LastName).NotEmpty().MaximumLength(100);
            RuleFor(candidate => candidate.PhoneNumber).NotEmpty().MaximumLength(32);
            RuleFor(candidate => candidate.EmailAddress).NotEmpty().MaximumLength(100);
            RuleFor(candidate => candidate.Comment).MaximumLength(2137);
        }
    }
}