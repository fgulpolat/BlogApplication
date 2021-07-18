using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired().HasColumnType("VARBINARY(500)");
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Picture).IsRequired().HasMaxLength(250);
            builder.Property(u => u.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();
            builder.Property(u => u.Note).HasMaxLength(500);
            builder.ToTable("Users");
            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Fatmagül",
                LastName = "Polat",
                UserName = "fgulpolat",
                Email = "polat.ftmgl@gmail.com",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreated",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreated",
                ModifiedDate = DateTime.Now,
                Description = "İlk admin kullanıcı",
                Note = "Admin kullanıcısı",
                PasswordHash = Encoding.ASCII.GetBytes("0192023A7BBD73250516F069DF18B500"),
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU"
            });
        }
    }
}
