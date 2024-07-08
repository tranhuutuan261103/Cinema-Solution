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
    internal class MovieImageTypeConfiguration : IEntityTypeConfiguration<MovieImageType>
    {
        public void Configure(EntityTypeBuilder<MovieImageType> builder)
        {
            builder.ToTable("MovieImageTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Description).HasMaxLength(256);

            builder.HasMany(x => x.MovieImages).WithOne(x => x.MovieImageType).HasForeignKey(x => x.MovieImageTypeId);
        }
    }
}
