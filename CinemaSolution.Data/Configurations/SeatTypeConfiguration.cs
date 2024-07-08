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
    internal class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
    {
        public void Configure(EntityTypeBuilder<SeatType> builder)
        {
            builder.ToTable("SeatTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(64);

            builder.HasMany(x => x.Seats).WithOne(x => x.SeatType).HasForeignKey(x => x.SeatTypeId);
            builder.HasMany(x => x.DefaultPriceTables).WithOne(x => x.SeatType).HasForeignKey(x => x.SeatTypeId);
        }
    }
}
