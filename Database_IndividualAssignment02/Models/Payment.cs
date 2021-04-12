using System;
using System.Collections.Generic;
using System.Text;

namespace Database_IndividualAssignment02.Models
{
    public class Payment
    {
        public Payment()
        {
            Orders = new List<Order>();
        }
        public Guid PaymentId { get; set; }
        public PaymentEnum PaymentEnum { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
    public enum PaymentEnum
    {
        INVALID = 0,
        VISA = 1,
        MASTERCARD = 2,
        MAESTRO = 3,
        AMEX = 4,
        KLARNA = 5,
        PAYPAL = 6,
    }
}
