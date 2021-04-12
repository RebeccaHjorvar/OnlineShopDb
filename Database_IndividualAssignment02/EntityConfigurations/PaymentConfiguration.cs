using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            #region PrimaryKey - Payment
            builder
                 .HasKey(pm => pm.PaymentId);
            builder
                .Property(pm => pm.PaymentId)
                .IsRequired();
            #endregion

            #region Payment
            builder
                .Property(pm => pm.PaymentEnum)
                .IsRequired();
            #endregion

            #region Order relation
            builder
                .HasMany(pm => pm.Orders)
                .WithOne(o => o.Payment);
            #endregion
            
        }
    }
}
