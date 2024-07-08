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
    internal class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
    {
        public void Configure(EntityTypeBuilder<Auditorium> builder)
        {
            builder.ToTable("Auditoriums");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            builder.Property(x => x.CinemaId).IsRequired();
            builder.Property(x => x.NumberOfRowSeats).IsRequired().HasDefaultValue(12);
            builder.Property(x => x.NumberOfColumnSeats).IsRequired().HasDefaultValue(12);

            builder.HasOne(x => x.Cinema).WithMany(x => x.Auditoriums).HasForeignKey(x => x.CinemaId);
        }
    }
}
