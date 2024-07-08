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
    internal class MovieInCategoryConfiguration : IEntityTypeConfiguration<MovieInCategory>
    {
        public void Configure(EntityTypeBuilder<MovieInCategory> builder)
        {
            builder.ToTable("MovieInCategories");
            builder.HasKey(x => new { x.MovieId, x.CategoryId });
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieInCategories).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Category).WithMany(x => x.MovieInCategories).HasForeignKey(x => x.CategoryId);
        }
    }
}
