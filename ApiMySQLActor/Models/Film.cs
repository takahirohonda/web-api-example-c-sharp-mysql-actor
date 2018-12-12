using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class Film
    {
        public Film()
        {
            FilmActor = new HashSet<FilmActor>();
            FilmCategory = new HashSet<FilmCategory>();
            Inventory = new HashSet<Inventory>();
        }

        public short FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short? ReleaseYear { get; set; }
        public byte LanguageId { get; set; }
        public byte? OriginalLanguageId { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Language Language { get; set; }
        public Language OriginalLanguage { get; set; }
        public ICollection<FilmActor> FilmActor { get; set; }
        public ICollection<FilmCategory> FilmCategory { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
