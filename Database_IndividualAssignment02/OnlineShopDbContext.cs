using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Database_IndividualAssignment02.Models;
using Database_IndividualAssignment02.EntityConfigurations;

namespace Database_IndividualAssignment02
{
    class OnlineShopDbContext : DbContext
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DASBARBIE\SQLEXPRESS;Database=OnlineShopDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new AddressConfiguration());

            modelBuilder
                .ApplyConfiguration(new ArticleConfiguration());

            modelBuilder
                .ApplyConfiguration(new CategoryConfiguration());

            modelBuilder
                .ApplyConfiguration(new CustomerConfiguration());


            modelBuilder
                .ApplyConfiguration(new OrderConfiguration());

            modelBuilder
                .ApplyConfiguration(new PaymentConfiguration());

            modelBuilder
                .ApplyConfiguration(new StockConfiguration());

        }
    }
}
