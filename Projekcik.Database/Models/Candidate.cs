using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projekcik.Database.Models
{
    public class Candidate : ICreatedAt
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CvPath { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> candidate)
        {
            candidate.HasKey(x => x.Id).IsClustered(false);
            candidate.Property(x => x.JobId).IsRequired();
            candidate.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            candidate.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            candidate.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(32);
            candidate.Property(x => x.EmailAddress).IsRequired().HasMaxLength(100);
            candidate.Property(x => x.CvPath).IsRequired();
            candidate.Property(x => x.Comment).HasMaxLength(2137);
            candidate.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
