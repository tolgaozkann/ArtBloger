using ArtBloger.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Data.Concrete.EntityFramework.Mappings
{
    internal class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).HasColumnType("NVARCHAR(MAX)");
            builder.Property(c => c.Text).IsRequired();
            builder.HasOne<Article>(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId);
            builder.ToTable("Comments");

            builder.HasData(
            new Comment
            {
                Id = 1,
                Text = "Yorum 1",
                ArticleId = 1,
            },
            new Comment
            {
                Id = 2,
                Text = "Yorum 2",
                ArticleId = 3,
            },
            new Comment
            {
                Id = 3,
                Text = "Yorum 3",
                ArticleId = 3
            });

        }
    }
}
