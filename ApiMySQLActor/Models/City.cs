using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public short CityId { get; set; }
        public string City1 { get; set; }
        public short CountryId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Country Country { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
