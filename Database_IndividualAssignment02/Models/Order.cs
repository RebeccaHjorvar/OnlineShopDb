using System;
using System.Collections.Generic;
using System.Text;

namespace Database_IndividualAssignment02.Models
{
    public class Order
    {
        public Order()
        {
            Articles = new List<Article>();
        }
        public Guid OrderId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public float PriceTotal { get; set; }
        public Payment Payment { get; set; }
        public Guid PaymentId { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

        public Guid ArticleId { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
