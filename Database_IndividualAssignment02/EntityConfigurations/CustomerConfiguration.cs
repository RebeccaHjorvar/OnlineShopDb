using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region Primary Key CustomerId
            builder
                .HasKey(c => c.CustomerId);
            builder
                .Property(c => c.CustomerId)
                .IsRequired();
            #endregion

            #region FirstName
            builder
                .Property(c => c.FirstName)
                .IsRequired();
            #endregion

            #region LastName
            builder
                .Property(c => c.LastName)
                .IsRequired();
            #endregion

            #region Email
            builder
                .Property(c => c.Email)
                .IsRequired();
            #endregion

            #region PhoneNr
            builder
                .Property(c => c.PhoneNr)
                .IsRequired();
            #endregion

            #region Address relation
            builder
                .HasOne(c => c.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.AddressID);
            #endregion

            #region Orders relation
            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.OrderId);
            #endregion

        }
    }
}
