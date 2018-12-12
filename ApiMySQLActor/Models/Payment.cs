using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class Payment
    {
        public short PaymentId { get; set; }
        public short CustomerId { get; set; }
        public byte StaffId { get; set; }
        public int? RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Customer Customer { get; set; }
        public Rental Rental { get; set; }
        public Staff Staff { get; set; }
    }
}
