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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(100);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.SeoAuthor).IsRequired();
            builder.Property(p => p.SeoAuthor).HasMaxLength(100);
            builder.Property(p => p.CreatedTime).IsRequired();
            builder.Property(p => p.SeoTags).IsRequired();
            builder.Property(p => p.SeoTags).HasMaxLength(70);
            builder.Property(p => p.SeoDescription).IsRequired();
            builder.Property(p => p.SeoDescription).HasMaxLength(150);
            builder.Property(p => p.ViewsCount).IsRequired();
            builder.Property(p => p.CommentCount).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(250);
            builder.HasOne<Category>(p => p.Category).WithMany(p => p.Articles).HasForeignKey(p => p.CategoryId);
            builder.HasOne<User>(p => p.User).WithMany(p => p.Articles).HasForeignKey(p => p.UserId);
            builder.ToTable("Articles");

            builder.HasData(
            new Article
            {
                Id = 1,
                Title = "Article 1",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ",
                SeoAuthor = "SeoAuthor 1",
                CreatedTime = DateTime.Now,
                SeoTags = "SeoTags 1",
                SeoDescription = "SeoDescription 1",
                ViewsCount = 331,
                CommentCount = 1,
                Image = "default.jpeg",
                CategoryId = 1,
                UserId = 1
            },
            new Article
            {
                Id = 2,
                Title = "Article 2",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ",
                SeoAuthor = "SeoAuthor 2",
                CreatedTime = DateTime.Now,
                SeoTags = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                SeoDescription = "Article 2",
                ViewsCount = 31,
                CommentCount = 1,
                Image = "default.jpeg",
                CategoryId = 2,
                UserId = 1,
            },
            new Article
            {
                Id = 3,
                Title = "Article 3",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ",
                SeoAuthor = "SeoAuthor 3",
                CreatedTime = DateTime.Now,
                SeoTags = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                SeoDescription = "Article 3",
                ViewsCount = 100,
                CommentCount = 1,
                Image = "default.jpeg",
                CategoryId = 3,
                UserId = 1,
            }
            );
        }
    }
}
