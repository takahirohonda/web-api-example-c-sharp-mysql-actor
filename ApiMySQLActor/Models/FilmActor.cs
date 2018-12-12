using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class FilmActor
    {
        public int ActorId { get; set; }
        public short FilmId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}
