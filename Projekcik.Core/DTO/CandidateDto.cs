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

        public CandidateDto(Guid id, Guid jobId, string firstName, string lastName, string phoneNumber,
            string emailAddress, string cvPath, string comment)
        {
            Id = id;
            JobId = jobId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            CvPath = cvPath;
            Comment = comment;
        }
    }

    public class CandidateDtoValidator : AbstractValidator<CandidateDto>
    {
        public CandidateDtoValidator()
        {
            RuleFor(candidate => candidate.FirstName).NotEmpty();
            RuleFor(candidate => candidate.LastName).NotEmpty();
            RuleFor(candidate => candidate.PhoneNumber).NotEmpty();
            RuleFor(candidate => candidate.EmailAddress).NotEmpty();
            RuleFor(candidate => candidate.Comment).MaximumLength(1024);
        }
    }
}