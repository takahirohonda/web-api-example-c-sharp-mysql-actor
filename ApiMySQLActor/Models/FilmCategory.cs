using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class FilmCategory
    {
        public short FilmId { get; set; }
        public byte CategoryId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Category Category { get; set; }
        public Film Film { get; set; }
    }
}
