using System;
using System.Collections.Generic;
using System.Text;

namespace Database_IndividualAssignment02.Models
{
    public class Stock
    {
        public Stock()
        {
            Articles = new List<Article>();
        }

        public Guid StockId { get; set; } 
        public int StockCount { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
