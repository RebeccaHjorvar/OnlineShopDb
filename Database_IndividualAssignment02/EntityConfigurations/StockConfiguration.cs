using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            #region PrimaryKey - StockId
            builder
                    .HasKey(s => s.StockId);
            builder
                .Property(s => s.StockId)
                .IsRequired();
            #endregion

            #region StockCount
            builder
                   .Property(s => s.StockCount)
                   .IsRequired();
            #endregion

            #region Article relation
            builder
                .HasMany(c => c.Articles)
                .WithOne(a => a.Stock);
            #endregion
        }
    }
}
