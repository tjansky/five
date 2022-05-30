using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {

            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .HasOne(m => m.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(m => m.AuthorId);

            builder
                .HasOne(m => m.Category)
                .WithMany(a => a.Articles)
                .HasForeignKey(m => m.CategoryId);

            builder
                .ToTable("Articles");
        }
    }
}
