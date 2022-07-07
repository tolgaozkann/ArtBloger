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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).HasMaxLength(100);
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(250);
            builder.Property(r => r.Description).IsRequired();
            builder.ToTable("Roles");
            //first role
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin Role has all the features.",
            });
        }
    }
}
