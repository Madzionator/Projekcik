using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projekcik.Database.Models
{
    public class Job : ICreatedAt, IModifiedAt
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? MinimumSalary { get; set; }
        public int? MaximumSalary { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }

    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> job)
        {
           job.HasKey(x => x.Id).IsClustered(false);
           job.Property(x => x.Title).IsRequired().HasMaxLength(100);
           job.Property(x => x.Description).IsRequired().HasMaxLength(4096);
           job.Property(x => x.CompanyName).IsRequired().HasMaxLength(100);
           job.Property(x => x.CreatedAt).IsRequired();
           job.Property(x => x.IsDeleted).HasDefaultValue(false);
           job.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}