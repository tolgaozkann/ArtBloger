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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.Property(u => u.UserName).IsRequired();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.Picture).IsRequired(false);
            builder.Property(u => u.Picture).HasMaxLength(200);
            builder.HasOne<Role>(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            builder.ToTable("Users");

            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Tolga",
                LastName = "Ozkan",
                Email = "tolgasukruozkan@gmail.com",
                UserName = "tolga",
                RoleId = 1,
                PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500"),
                Picture = "https://avatars3.githubusercontent.com/u/527058?s=460&v=4"

            });

        }
    }
}
