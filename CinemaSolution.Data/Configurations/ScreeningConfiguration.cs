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
    internal class ScreeningConfiguration : IEntityTypeConfiguration<Screening>
    {
        public void Configure(EntityTypeBuilder<Screening> builder)
        {
            builder.ToTable("Screenings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.StartDate).IsRequired().HasColumnType("date");
            builder.Property(x => x.StartTime).IsRequired().HasColumnType("time");
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasOne(x => x.Movie).WithMany(x => x.Screenings).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Auditorium).WithMany(x => x.Screenings).HasForeignKey(x => x.AuditoriumId);
        }
    }
}
