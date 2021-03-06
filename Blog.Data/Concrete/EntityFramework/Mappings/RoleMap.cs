using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired().HasMaxLength(30);
            builder.Property(r => r.Description).IsRequired().HasMaxLength(250);
            builder.Property(r => r.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(r => r.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(r => r.CreatedDate).IsRequired();
            builder.Property(r => r.ModifiedDate).IsRequired();
            builder.Property(r => r.IsActive).IsRequired();
            builder.Property(r => r.IsDeleted).IsRequired();
            builder.Property(r => r.Note).HasMaxLength(500);
            builder.ToTable("Role");
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin rolü, tüm haklara sahiptir",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "Initialcreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "Initialcreate",
                ModifiedDate = DateTime.Now,
                Note = "Admin rolüdür"

            });
        }
    }
}
