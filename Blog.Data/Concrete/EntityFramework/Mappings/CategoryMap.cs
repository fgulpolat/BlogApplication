using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Category");

            builder.HasData(new Category
            {
                Id = 1,
                Name = "C#",
                Description = "C# Programlama Dili ile ilgili En güncel bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# Blog Kategorisi"
            },
          new Category
          {
              Id = 2,
              Name = "C++",
              Description = "C++ Programlama Dili ile ilgili En güncel bilgiler",
              IsActive = true,
              IsDeleted = false,
              CreatedByName = "InitialCreate",
              CreatedDate = DateTime.Now,
              ModifiedByName = "InitialCreate",
              ModifiedDate = DateTime.Now,
              Note = "C++ Blog Kategorisi"
          },
          new Category
          {
              Id = 3,
              Name = "Java",
              Description = "Java Programlama Dili ile ilgili En güncel bilgiler",
              IsActive = true,
              IsDeleted = false,
              CreatedByName = "InitialCreate",
              CreatedDate = DateTime.Now,
              ModifiedByName = "InitialCreate",
              ModifiedDate = DateTime.Now,
              Note = "Java Blog Kategorisi"
          }
          );
        }
    }
}
