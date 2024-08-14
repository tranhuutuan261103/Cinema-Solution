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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(64);
            builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(32);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(320);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(32);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(32);
            builder.Property(x => x.PhoneNumber).HasMaxLength(16);
            builder.Property(x => x.Address).HasMaxLength(128);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.AvatarUrl).HasMaxLength(256);
            builder.Property(x => x.BackgroundUrl).HasMaxLength(256);

            //builder.HasMany(x => x.Tickets).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Ratings).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
