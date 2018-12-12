using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class Language
    {
        public Language()
        {
            FilmLanguage = new HashSet<Film>();
            FilmOriginalLanguage = new HashSet<Film>();
        }

        public byte LanguageId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<Film> FilmLanguage { get; set; }
        public ICollection<Film> FilmOriginalLanguage { get; set; }
    }
}
