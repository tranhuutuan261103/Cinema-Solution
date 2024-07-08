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
    internal class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seat");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Row).IsRequired();
            builder.Property(x => x.Number).IsRequired();

            builder.HasOne(x => x.SeatType).WithMany(x => x.Seats).HasForeignKey(x => x.SeatTypeId);
            builder.HasOne(x => x.Screening).WithMany(x => x.Seats).HasForeignKey(x => x.ScreeningId);
            builder.HasOne(x => x.PersonType).WithMany(x => x.Seats).HasForeignKey(x => x.PersonTypeId);
            builder.HasOne(x => x.Ticket).WithMany(x => x.Seats).HasForeignKey(x => x.TicketId);
        }
    }
}
