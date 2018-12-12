using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiMySQLActor.Models;
using ApiMySQLActor.Repositories;

namespace ApiMySQLActor.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private IActorsRepository actors;

        public ActorsController(sakilaContext context)
        {
            actors = new ActorsRepository(context);
        }

        // GET api/actors
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(actors.GetActors());
        }

        // GET api/actors/101
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Actor actor = actors.GetActorById(id);
            if (actor != null)
            {
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/actors
        [HttpPost]
        public IActionResult Post([FromBody]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int success = actors.AddNewActor(actor);
            if (success == 1)
            {
                return Created("api/actors", actor);
            }
            return BadRequest();
        }

        // PUT api/actors
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            // int success = actors.UpdateActorById(id, actor);
            int success = actors.UpdateActorByIdEntityState(id, actor);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE api/actors
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int success = actors.DeleteActorById(id);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}