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
    internal class ProductInProductComboConfiguration : IEntityTypeConfiguration<ProductInProductCombo>
    {
        public void Configure(EntityTypeBuilder<ProductInProductCombo> builder)
        {
            builder.ToTable("ProductInProductCombos");
            builder.HasKey(x => new { x.ProductId, x.ProductComboId });
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.ProductCombo).WithMany(x => x.ProductInProductCombos).HasForeignKey(x => x.ProductComboId);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductInProductCombos).HasForeignKey(x => x.ProductId);
        }
    }
}
