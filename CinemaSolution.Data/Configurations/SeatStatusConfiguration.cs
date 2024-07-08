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
    internal class SeatStatusConfiguration : IEntityTypeConfiguration<SeatStatus>
    {
        public void Configure(EntityTypeBuilder<SeatStatus> builder)
        {
            builder.ToTable("SeatStatuses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.StatusName).IsRequired().HasMaxLength(32);
            builder.Property(x => x.StatusDescription).IsRequired().HasMaxLength(64);

            builder.HasMany(x => x.Seats).WithOne(x => x.SeatStatus).HasForeignKey(x => x.SeatStatusId);
        }
    }
}
