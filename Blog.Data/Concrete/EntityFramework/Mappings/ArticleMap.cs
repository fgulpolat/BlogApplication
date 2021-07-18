using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(50);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCounts).IsRequired();
            builder.Property(a => a.ThumbNail).HasMaxLength(100);
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a=>a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(u => u.UserId);
            builder.HasData(new Article
            {
                Id = 1,
                CategoryId = 1,
                Title = "C# 9.0 ve .NET yenilikleri",
                Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose",
                ThumbNail = "Default.jpeg",
                SeoDescription = "C# 9.0 ve .NET yenilikleri",
                SeoTags = "C#,ASP.NET",
                SeoAuthor = "Fatmagül Polat",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreated",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreated",
                Note = "C# 9.0 ve .NET yenilikleri",
                UserId = 1

            },
           new Article
           {
               Id = 2,
               CategoryId = 2,
               Title = "C++ 11 ve 19 yenilikleri",
               Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose",
               ThumbNail = "Default.jpeg",
               SeoDescription = "C++ 11 ve 19 yenilikleri",
               SeoTags = "C++",
               SeoAuthor = "Fatmagül Polat",
               Date = DateTime.Now,
               IsActive = true,
               IsDeleted = false,
               CreatedByName = "InitialCreated",
               CreatedDate = DateTime.Now,
               ModifiedByName = "InitialCreated",
               Note = "C++ 9.0 ve .NET yenilikleri",
               UserId = 1

           },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "Java 11 ve 19 yenilikleri",
                Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose",
                ThumbNail = "Default.jpeg",
                SeoDescription = "Java 11 ve 19 yenilikleri",
                SeoTags = "Java",
                SeoAuthor = "Fatmagül Polat",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreated",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreated",
                Note = "Java 9.0 ve .NET yenilikleri",
                UserId = 1

            }
           );
        }
    }
}
