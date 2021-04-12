using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            #region PrimaryKey - ArticleNr
            builder
                    .HasKey(a => a.ArticleNr);
            builder
                .Property(a => a.ArticleNr)
                .IsRequired();
            #endregion

            #region ArticleName
            builder
                   .Property(a => a.ArticleName)
                   .IsRequired();
            #endregion

            #region ArticleDescription
            builder
                .Property(a => a.ArticleDescription)
                .IsRequired();
            #endregion

            #region ArticlePrice
            builder
                .Property(a => a.ArticlePrice)
                .IsRequired();
            #endregion

            #region Category relation

            builder
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId);
            #endregion

            #region Stock relation
            builder
                .HasOne(a => a.Stock)
                .WithMany(s => s.Articles)
            .HasForeignKey(a => a.StockId);
            #endregion

            #region Orders relation
            builder
                .HasMany(a => a.Orders)
                .WithMany(o => o.Articles);
            #endregion


        }
    }
}
