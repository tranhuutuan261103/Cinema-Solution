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
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(256);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.Movie).WithMany(x => x.Comments).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Parent) // Thiết lập quan hệ tự tham chiếu
            .WithMany(x => x.Replies)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict); // Đảm bảo không xóa cha khi xóa con
        }
    }
}
