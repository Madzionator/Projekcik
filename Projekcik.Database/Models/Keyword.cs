using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projekcik.Database.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Job> Candidate { get; set; }
    }

    public class KeywordMap : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> keyword)
        {
            keyword.HasKey(x => x.Id).IsClustered(false);
            keyword.Property(x => x.Name).IsRequired().HasMaxLength(64);
        }
    }
}