using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region PrimaryKey - CategoryId
            builder
                    .HasKey(c => c.CategoryId);
            builder
                .Property(c => c.CategoryId)
                .IsRequired();
            #endregion

            #region CategoryName
            builder
                   .Property(c => c.CategoryName)
                   .IsRequired();
            #endregion

            #region CategoryDescription
            builder
                .Property(c => c.CategoryDescription)
                .IsRequired();
            #endregion

            #region Articles relation
            builder
                .HasMany(c => c.Articles)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.ArticleNr);
            #endregion  

        }
    }
}
