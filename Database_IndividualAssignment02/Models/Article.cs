using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database_IndividualAssignment02.Models
{
    public class Article
    {
        public Article()
        {
            Orders = new List<Order>();
        }
        public Guid ArticleNr { get; set; } 
        public string ArticleName { get; set; } 
        public string ArticleDescription { get; set; } 
        public float ArticlePrice { get; set; } 
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Stock Stock { get; set; }
        public Guid StockId { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Guid OrderId { get; set; }
    }
}
