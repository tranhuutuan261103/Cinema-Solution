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
    internal class ProductComboConfiguration : IEntityTypeConfiguration<ProductCombo>
    {
        public void Configure(EntityTypeBuilder<ProductCombo> builder)
        {
            builder.ToTable("ProductCombos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Description).HasMaxLength(128);
            builder.Property(x => x.ImageUrl).HasMaxLength(256).IsRequired(false);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
