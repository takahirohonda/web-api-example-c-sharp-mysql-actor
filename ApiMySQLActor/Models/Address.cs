using System;
using System.Collections.Generic;
using MySql.Data.Types;

namespace ApiMySQLActor.Models
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
            Staff = new HashSet<Staff>();
            Store = new HashSet<Store>();
        }

        public short AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string District { get; set; }
        public short CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public MySqlGeometry Location { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public City City { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public ICollection<Store> Store { get; set; }
    }
}
