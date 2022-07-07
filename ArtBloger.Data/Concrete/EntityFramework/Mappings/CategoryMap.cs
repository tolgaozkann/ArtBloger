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
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Name).IsRequired();
            builder.ToTable("Categories");

            builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Kategori 1",
                
            },
            new Category
            {
                Id = 2,
                Name = "Kategori 2",

            },
            new Category
            {
                Id = 3,
                Name = "Kategori 3",

            });
        }
    }
}
