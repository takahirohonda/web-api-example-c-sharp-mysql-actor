using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace ApiMySQLActor.Models
{
    public interface IsakilaContext
    {
        DbSet<Actor> Actor { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<City> City { get; set; }
        DbSet<Country> Country { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Film> Film { get; set; }
        DbSet<FilmActor> FilmActor { get; set; }
        DbSet<FilmCategory> FilmCategory { get; set; }
        DbSet<FilmText> FilmText { get; set; }
        DbSet<Inventory> Inventory { get; set; }
        DbSet<Language> Language { get; set; }
        DbSet<Payment> Payment { get; set; }
        DbSet<Rental> Rental { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<Store> Store { get; set; }

        int SaveChanges();
        EntityEntry Entry(Object entity);

        void MarkAsModified(Actor actor);

    }
}