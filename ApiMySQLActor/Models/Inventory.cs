using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rental = new HashSet<Rental>();
        }

        public int InventoryId { get; set; }
        public short FilmId { get; set; }
        public byte StoreId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Film Film { get; set; }
        public Store Store { get; set; }
        public ICollection<Rental> Rental { get; set; }
    }
}
