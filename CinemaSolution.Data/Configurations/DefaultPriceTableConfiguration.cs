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
    public class DefaultPriceTableConfiguration : IEntityTypeConfiguration<DefaultPriceTable>
    {
        public void Configure(EntityTypeBuilder<DefaultPriceTable> builder)
        {
            builder.ToTable("DefaultPriceTables");
            builder.HasKey(x => new { x.SeatTypeId, x.PersonTypeId });
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(50000);

            builder.HasOne(x => x.SeatType).WithMany(x => x.DefaultPriceTables).HasForeignKey(x => x.SeatTypeId);
            builder.HasOne(x => x.PersonType).WithMany(x => x.DefaultPriceTables).HasForeignKey(x => x.PersonTypeId);
        }
    }
}
