using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaSolution.Data.Configurations
{
    internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");
            builder.HasKey(x => new { x.MovieId, x.UserId });
            builder.Property(x => x.Value).IsRequired().HasDefaultValue(0);

            builder.HasOne(x => x.Movie).WithMany(x => x.Ratings).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.User).WithMany(x => x.Ratings).HasForeignKey(x => x.UserId);
        }
    }
}
