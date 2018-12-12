using ApiMySQLActor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMySQLActorUnitTest.Models
{
    public class MockActors
    {
        public List<Actor> Actors;

        public MockActors()
        {
            Actors = new List<Actor>();
            Actors.Add(new Actor { ActorId = 1, FirstName = "Hello", LastName = "World", LastUpdate = DateTime.Now, FilmActor = new List<FilmActor>() });
            Actors.Add(new Actor { ActorId = 2, FirstName = "Second", LastName = "Record", LastUpdate = DateTime.Now, FilmActor = new List<FilmActor>() });
        }
    }
}
