using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;

namespace Database_IndividualAssignment02.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            #region PrimaryKey - AddressId
            builder
                    .HasKey(a => a.AddressId);
            builder
                .Property(a => a.AddressId)
                .IsRequired();
            #endregion

            #region StreetName
            builder
                   .Property(a => a.StreetName)
                   .IsRequired();
            #endregion

            #region PostalCode
            builder
                .Property(a => a.PostalCode)
                .IsRequired();
            #endregion

            #region City
            builder
                .Property(a => a.City)
                .IsRequired();
            #endregion

            #region Customer relation
            builder
                .HasMany(a => a.Customers)
                .WithOne(c => c.Address)
                .HasForeignKey(x => x.CustomerId);
            #endregion

        }
    }
}
