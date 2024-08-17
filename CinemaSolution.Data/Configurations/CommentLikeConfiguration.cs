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
    public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.ToTable("CommentLikes");
            builder.HasKey(x => new { x.CommentId, x.UserId });
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User)
            .WithMany(x => x.CommentLikes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Hoặc .OnDelete(DeleteBehavior.NoAction)

            builder.HasOne(x => x.Comment)
            .WithMany(x => x.CommentLikes)
            .HasForeignKey(x => x.CommentId)
            .OnDelete(DeleteBehavior.Restrict); // Hoặc .OnDelete(DeleteBehavior.NoAction)
        }
    }
}
