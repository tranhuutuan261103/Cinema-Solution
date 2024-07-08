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
    internal class ProductComboInOrderConfiguration : IEntityTypeConfiguration<ProductComboInOrder>
    {
        public void Configure(EntityTypeBuilder<ProductComboInOrder> builder)
        {
            builder.ToTable("ProductComboInOrders");
            builder.HasKey(x => new { x.OrderId, x.ProductComboId });
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);

            builder.HasOne(x => x.Order).WithMany(x => x.ProductComboInOrders).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.ProductCombo).WithMany(x => x.ProductComboInOrders).HasForeignKey(x => x.ProductComboId);
        }
    }
}
