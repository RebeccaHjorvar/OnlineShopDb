using System;
using System.Collections.Generic;
using System.Text;

namespace Database_IndividualAssignment02.Models
{
    public class Category
    {
        public Category()
        {
            Articles = new List<Article>();
        }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
