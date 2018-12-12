using ApiMySQLActor.Models;

namespace ApiMySQLActor.Repositories
{
    public interface IActorsRepository
    {
        int AddNewActor(Actor actor);
        int DeleteActorById(int id);
        Actor GetActorById(int id);
        Actor[] GetActors();
        int UpdateActorById(int id, Actor actor);
        int UpdateActorByIdEntityState(int id, Actor actor);
    }
}