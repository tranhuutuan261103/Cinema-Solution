using CinemaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Configurations
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(seed: 100000);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Discount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SumPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.DateOfPurchase).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.Property(x => x.TicketId).IsRequired(false);
            builder.Property(x => x.OrderId).IsRequired(false);

            builder.HasOne(x => x.User).WithMany(x => x.Invoices).HasForeignKey(x => x.UserId);
            builder.HasOne(i => i.Ticket).WithOne(t => t.Invoice).HasForeignKey<Invoice>(t => t.TicketId);
            builder.HasOne(i => i.Order).WithOne(o => o.Invoice).HasForeignKey<Invoice>(o => o.OrderId);
        }
    }
}
