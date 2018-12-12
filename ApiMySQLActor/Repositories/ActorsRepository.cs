using ApiMySQLActor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMySQLActor.Repositories
{
    public class ActorsRepository : IActorsRepository
    {
        private IsakilaContext _context;

        public ActorsRepository (IsakilaContext context)
        {
            _context = context;
        }

        public Actor[] GetActors()
        {
            return _context.Actor.ToArray();
        }

        public Actor GetActorById(int id)
        {
            var actor = _context.Actor.SingleOrDefault(a => a.ActorId == id);
            return actor;
        }

        // Better to use EntityState.Modified to update for unit testing
        public int UpdateActorById(int id, Actor actor)
        {
            int updateSuccess = 0;
            var target = _context.Actor.SingleOrDefault(a => a.ActorId == id);
            if(target != null)
            {
                _context.Entry(target).CurrentValues.SetValues(actor);
                updateSuccess =_context.SaveChanges();
            }
            return updateSuccess;
        }

        // This is a better approach for unit testing
        public int UpdateActorByIdEntityState(int id, Actor actor)
        {
            int updateSuccess = 0;
            if (id != actor.ActorId)
            {
                return updateSuccess;
            }
            _context.MarkAsModified(actor);
            updateSuccess = _context.SaveChanges();
            return updateSuccess;
        }

        public int AddNewActor(Actor actor)
        {
            int insertSuccess = 0;
            int maxId = _context.Actor.Max(p => p.ActorId);

            actor.ActorId = (short) (maxId + 1);
            _context.Actor.Add(actor);
            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }

        public int DeleteActorById(int id)
        {
            int deleteSuccess = 0;
            var actor = _context.Actor.SingleOrDefault(a => a.ActorId == id);
            if (actor != null)
            {
                _context.Actor.Remove(actor);
                deleteSuccess = _context.SaveChanges();
            }
            return deleteSuccess;
        }
    }
}
