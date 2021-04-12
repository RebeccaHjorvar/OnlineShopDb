using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;
using System.Linq;

namespace Database_IndividualAssignment02.Methods
{
    class Seeds
    {
        public void Seed()
        {
            OnlineShopDbContext context = new OnlineShopDbContext();

            #region Seeds addresses

            var address1 = new Address { 
                AddressId = new Guid(), 
                StreetName = "Lucy street 8", 
                PostalCode = "15643", 
                City = "Strawberryfields", };

            var address2 = new Address { 
                AddressId = new Guid(), 
                StreetName = "Creep lane 2", 
                PostalCode = "87952", 
                City = "Radiocity", };

            var address3 = new Address { 
                AddressId = new Guid(), 
                StreetName = "Low lane 1",
                PostalCode = "75125", 
                City = "Florida", };

            var address4 = new Address { 
                AddressId = new Guid(), 
                StreetName = "Sunshine ally 5", 
                PostalCode = "96548", 
                City = "Godzillatown", };

            var address5 = new Address { 
                AddressId = new Guid(), 
                StreetName = "Freak square 9", 
                PostalCode = "12546", 
                City = "Missiselliot", };

            context.Addresses.Add(address1);
            context.Addresses.Add(address2);
            context.Addresses.Add(address3);
            context.Addresses.Add(address4);
            context.Addresses.Add(address5);
            context.SaveChanges();

            #endregion

            #region Seeds customers

            var customer1 = new Customer
            {
                CustomerId = new Guid(),
                FirstName = "Paul",
                LastName = "McCartney",
                Email = "mcC@gmail.com",
                PhoneNr = "0700458569",
                AddressID = address1.AddressId
            };

            var customer2 = new Customer
            {
                CustomerId = new Guid(),
                FirstName = "Tom",
                LastName = "York",
                Email = "radioHead@outlook.com",
                PhoneNr = "0765124586",
                AddressID = address2.AddressId
            };

            var customer3 = new Customer { 
                CustomerId = new Guid(), 
                FirstName = "Tramar", 
                LastName = "Dillard", 
                Email = "floRida@hotmail.com", 
                PhoneNr = "0765932156", 
                AddressID = address3.AddressId };

            var customer4 = new Customer { 
                CustomerId = new Guid(), 
                FirstName = "Golden", 
                LastName = "Jacob", 
                Email = "zillmaister@mail.com", 
                PhoneNr = "0723651248", 
                AddressID = address4.AddressId };

            var customer5 = new Customer { 
                CustomerId = new Guid(), 
                FirstName = "Melissa", 
                LastName = "Elliott", 
                Email = "missy@mail.com", 
                PhoneNr = "0701256325", 
                AddressID = address5.AddressId };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Customers.Add(customer5);
            context.SaveChanges();

            #endregion

            #region Seeds categorys
            var category1 = new Category
            {
                CategoryId = new Guid(),
                CategoryName = "Eyeliner",
                CategoryDescription = "Eyeliners in every form"
            };

            var category2 = new Category
            {
                CategoryId = new Guid(),
                CategoryName = "Primer",
                CategoryDescription = "Primers for a smooth base"
            };

            var category3 = new Category
            {
                CategoryId = new Guid(),
                CategoryName = "Setter",
                CategoryDescription = "Setters that make your makeup last"
            };

            var category4 = new Category
            {
                CategoryId = new Guid(),
                CategoryName = "Concealer",
                CategoryDescription = "Concealers to perfect your imperfections"
            };

            var category5 = new Category
            {
                CategoryId = new Guid(),
                CategoryName = "Eyeshadow",
                CategoryDescription = "Eyeshadow palettes for every occation"
            };

            context.Categorys.Add(category1);
            context.Categorys.Add(category2);
            context.Categorys.Add(category3);
            context.Categorys.Add(category4);
            context.Categorys.Add(category5);
            context.SaveChanges();

            #endregion

            #region Seeds stock

            var stock1 = new Stock
            {
                StockId = new Guid(),
                StockCount = 5
            };
            var stock2 = new Stock
            {
                StockId = new Guid(),
                StockCount = 10
            };
            var stock3 = new Stock
            {
                StockId = new Guid(),
                StockCount = 7
            };
            var stock4 = new Stock
            {
                StockId = new Guid(),
                StockCount = 3
            };
            var stock5 = new Stock
            {
                StockId = new Guid(),
                StockCount = 4
            };

            context.Stocks.Add(stock1);
            context.Stocks.Add(stock2);
            context.Stocks.Add(stock3);
            context.Stocks.Add(stock4);
            context.Stocks.Add(stock5);
            context.SaveChanges();

            #endregion

            #region Seeds articles

            var article1 = new Article
            {
                ArticleNr = new Guid(),
                ArticleName = "Heavy Metal",
                ArticleDescription = "Glitter liner",
                ArticlePrice = 205,
                CategoryId = category1.CategoryId,
                StockId = stock1.StockId
            };

            var article2 = new Article
            {
                ArticleNr = new Guid(),
                ArticleName = "Naked Heat",
                ArticleDescription = "Eyeshadow palette",
                ArticlePrice = 530,
                CategoryId = category5.CategoryId,
                StockId = stock2.StockId
            };

            var article3 = new Article
            {
                ArticleNr = new Guid(),
                ArticleName = "All Nighter",
                ArticleDescription = "Ultra Glow Primer",
                ArticlePrice = 500,
                CategoryId = category2.CategoryId,
                StockId = stock3.StockId
            };

            var article4 = new Article
            {
                ArticleNr = new Guid(),
                ArticleName = "Stay NAKED",
                ArticleDescription = "Concealer",
                ArticlePrice = 275,
                CategoryId = category4.CategoryId,
                StockId = stock4.StockId
            };

            var article5 = new Article
            {
                ArticleNr = new Guid(),
                ArticleName = "All Nighter Ultra Glow",
                ArticleDescription = "Setting spray",
                ArticlePrice = 320,
                CategoryId = category3.CategoryId,
                StockId = stock5.StockId
            };

            //context.Articles.Add(article1);
            //context.Articles.Add(article2);
            //context.Articles.Add(article3);
            //context.Articles.Add(article4);
            //context.Articles.Add(article5);
            //context.SaveChanges();
            //
            // Since I wasn't able to add to this table the seed for the orders table wasn't working eather.
            // I decided to comment them out so you could at least try ot the application
            #endregion

            #region Seeds payment

            var payment1 = new Payment { 
                PaymentId = new Guid(), 
                PaymentEnum = (PaymentEnum)1 };

            var payment2 = new Payment { 
                PaymentId = new Guid(), 
                PaymentEnum = (PaymentEnum)2 };

            var payment3 = new Payment { 
                PaymentId = new Guid(), 
                PaymentEnum = (PaymentEnum)3 };

            var payment4 = new Payment { 
                PaymentId = new Guid(), 
                PaymentEnum = (PaymentEnum)4 };

            var payment5 = new Payment { 
                PaymentId = new Guid(), 
                PaymentEnum = (PaymentEnum)5 };

            context.Payments.Add(payment1);
            context.Payments.Add(payment2);
            context.Payments.Add(payment3);
            context.Payments.Add(payment4);
            context.Payments.Add(payment5);
            context.SaveChanges();

            #endregion

            #region Seeds orders

            var order1 = new Order
            {
                OrderId = new Guid(),
                DateOfOrder = new DateTime(),
                PriceTotal = article1.ArticlePrice + article2.ArticlePrice,
                PaymentId = payment1.PaymentId,
                Articles = new List<Article> { article1, article2 }
            };
            var order2 = new Order
            {
                OrderId = new Guid(),
                DateOfOrder = new DateTime(),
                PriceTotal = article2.ArticlePrice + article5.ArticlePrice + article4.ArticlePrice,
                PaymentId = payment2.PaymentId,
                Articles = new List<Article> { article2, article5, article4 }
            };
            var order3 = new Order
            {
                OrderId = new Guid(),
                DateOfOrder = new DateTime(),
                PriceTotal = article4.ArticlePrice + article3.ArticlePrice,
                PaymentId = payment3.PaymentId,
                Articles = new List<Article> { article3, article4 }
            };
            var order4 = new Order
            {
                OrderId = new Guid(),
                DateOfOrder = new DateTime(),
                PriceTotal = article4.ArticlePrice,
                PaymentId = payment4.PaymentId,
                Articles = new List<Article> { article4 }
            };
            var order5 = new Order
            {
                OrderId = new Guid(),
                DateOfOrder = new DateTime(),
                PriceTotal = article1.ArticlePrice * 3,
                PaymentId = payment5.PaymentId,
                Articles = new List<Article> { article1, article1, article1 }
            };

            //context.Orders.Add(order1);
            //context.Orders.Add(order2);
            //context.Orders.Add(order3);
            //context.Orders.Add(order4);
            //context.Orders.Add(order5);
            //context.SaveChanges();

            // Se the comment for the articles seed. ^

            #endregion

        }
    }
}
