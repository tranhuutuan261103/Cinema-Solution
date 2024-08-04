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
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Language).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Director).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Actors).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).HasMaxLength(2048);
            builder.Property(x => x.Duration).IsRequired();

            builder.Property(x => x.ReleaseDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EndDate).IsRequired();


            builder.Property(x => x.TrailerUrl).HasMaxLength(256);

            builder.Property(x => x.Rating).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasMany(x => x.MovieImages).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.Ratings).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            builder.HasMany(x => x.Comments).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
        }
    }
}
