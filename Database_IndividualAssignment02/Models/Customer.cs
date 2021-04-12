using System;
using System.Collections.Generic;
using System.Text;

namespace Database_IndividualAssignment02.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; } // selected string to avoid user error
        public Address Address { get; set; }
        public Guid AddressID { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
