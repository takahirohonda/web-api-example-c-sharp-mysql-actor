using ApiMySQLActor.Models;
using ApiMySQLActor.Repositories;
using ApiMySQLActorUnitTest.Models;
using ApiMySQLActorUnitTest.Utilities;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace ApiMySQLActorUnitTest
{
    public class ActorsRepositoryTest
    {
        private MockActors _Actors;
        private DbSet<Actor> _mockDbSet;
        private IsakilaContext _mockSakilaContext;
        private ActorsRepository _actors;

        public ActorsRepositoryTest()
        {
            this._Actors = new MockActors();
            this._mockDbSet = NSubstituteUtils.CreateMockDbSet(_Actors.Actors);
            this._mockSakilaContext = Substitute.For<IsakilaContext>();
            _mockSakilaContext.Actor.Returns(_mockDbSet);
            this._actors = new ActorsRepository(_mockSakilaContext);
        }
 
        [Fact]
        public void GetActors_Should_Return_Correct_Actor()
        {
            // Arrange - Constructor to initialize

            // Act
            var data = _actors.GetActors();

            // Assert
            data[0].FirstName.Should().Be("Hello");
        }

        [Fact]
        public void GetActors_Should_Return_All_Actors()
        {
            // Arrange - Constructor to initialize

            // Act
            var data = _actors.GetActors();

            // Assert
            data.Should().HaveCount(2);
        }

        [Fact]
        public void UpdateActorByIdEntityState_Should_Return_1_When_Actor_Exists_In_DB()
        {
            // Arrange
            int id = 1;
            Actor newActor = new Actor { ActorId = 1, FirstName = "Updated", LastName = "Actor", LastUpdate = DateTime.Now, FilmActor = new List<FilmActor>() };
            var counter = 0;

            // Act
            _mockSakilaContext.When(x => x.MarkAsModified(newActor)).Do(x => counter++);
            _mockSakilaContext.SaveChanges().Returns(1);
            int success = _actors.UpdateActorByIdEntityState(id, newActor);

            // Assert
            success.Should().Be(1);
        }

        [Fact]
        public void MarkAsModified_Method_Should_Be_Called_Once_When_Actor_Exists_In_DB()
        {
            // Arrange
            int id = 1;
            Actor newActor = new Actor { ActorId = 1, FirstName = "Updated", LastName = "Actor", LastUpdate = DateTime.Now, FilmActor = new List<FilmActor>() };
            var counter = 0;

            // Act
            _mockSakilaContext.When(x => x.MarkAsModified(newActor)).Do(x => counter++);
            _mockSakilaContext.SaveChanges().Returns(1);
            int success = _actors.UpdateActorByIdEntityState(id, newActor);

            // Assert
            counter.Should().Be(1);
        }

        [Fact]
        public void UpdateActorByIdEntityState_Should_Return_0_When_Actor_DoesnNot_Exist()
        {
            // Arrange
            int id = 1;
            Actor newActor = new Actor { ActorId = 100, FirstName = "Updated", LastName = "Actor", LastUpdate = DateTime.Now, FilmActor = new List<FilmActor>() };
            var counter = 0;

            // Act
            _mockSakilaContext.When(x => x.MarkAsModified(newActor)).Do(x => counter++);
            _mockSakilaContext.SaveChanges().Returns(1);
            int success = _actors.UpdateActorByIdEntityState(id, newActor);

            // Assert
            success.Should().Be(0);
        }

        [Fact]
        public void MarkAsModified_Should_Not_Execute_MarkAsModified_Method_When_Actor_DoesnNot_Exist()
        {
            // Arrange
            int id = 1;
            Actor newActor = new Actor { ActorId = 100, FirstName = "Updated", LastName = "Actor", LastUpdate = DateTime.Now, FilmActor = new List<FilmActor>() };
            var counter = 0;

            // Act
            _mockSakilaContext.When(x => x.MarkAsModified(newActor)).Do(x => counter++);
            _mockSakilaContext.SaveChanges().Returns(1);
            int success = _actors.UpdateActorByIdEntityState(id, newActor);

            // Assert
            counter.Should().Be(0);
        }
    }
}
