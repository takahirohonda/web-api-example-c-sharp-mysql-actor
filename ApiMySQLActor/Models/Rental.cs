using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class Rental
    {
        public Rental()
        {
            Payment = new HashSet<Payment>();
        }

        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public int InventoryId { get; set; }
        public short CustomerId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public byte StaffId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Customer Customer { get; set; }
        public Inventory Inventory { get; set; }
        public Staff Staff { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
