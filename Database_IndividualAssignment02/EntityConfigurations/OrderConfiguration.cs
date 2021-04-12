using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            #region Primary Key OrderId
            builder
                .HasKey(o => o.OrderId);
            builder
                .Property(o => o.OrderId)
                .IsRequired();
            #endregion

            #region DateOfOrder
            builder
                .Property(o => o.DateOfOrder)
                .IsRequired();
            #endregion

            #region PriceTotal
            builder
                .Property(o => o.PriceTotal)
                .IsRequired();
            #endregion

            #region PaymentMethod relation
            builder
                .HasOne(o => o.Payment)
                .WithMany(pm => pm.Orders)
                .HasForeignKey(x => x.PaymentId);
            #endregion

            #region Customer relation
            builder
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            #endregion

            #region Articles relation
            builder
                .HasMany(o => o.Articles)
                .WithMany(a => a.Orders);
            #endregion
               
        }
    }
}
