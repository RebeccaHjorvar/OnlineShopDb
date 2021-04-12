using System;
using System.Collections.Generic;
using System.Text;

namespace Database_IndividualAssignment02.Models
{
    public class Address
    {
        public Address()
        {
            Customers = new List<Customer>();
        }
        public Guid AddressId { get; set; } 
        public string StreetName { get; set; } 
        public string PostalCode {get; set;} 
        public string City { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
