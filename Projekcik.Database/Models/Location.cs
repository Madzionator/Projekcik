using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projekcik.Database.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }

    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> location)
        {
            location.HasKey(x => x.Id).IsClustered(false);
            location.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}