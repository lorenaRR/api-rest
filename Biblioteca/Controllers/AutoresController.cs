using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Biblioteca;

namespace Biblioteca.Controllers
{
    public class AutoresController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Autores
        public IQueryable<Autores> GetAutores1()
        {
            return db.Autores1;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(Autores))]
        public IHttpActionResult GetAutores(int id)
        {
            Autores autores = db.Autores1.Find(id);
            if (autores == null)
            {
                return NotFound();
            }

            return Ok(autores);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutores(int id, Autores autores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autores.id_autor)
            {
                return BadRequest();
            }

            db.Entry(autores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Autores
        [ResponseType(typeof(Autores))]
        public IHttpActionResult PostAutores(Autores autores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Autores1.Add(autores);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AutoresExists(autores.id_autor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autores.id_autor }, autores);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(Autores))]
        public IHttpActionResult DeleteAutores(int id)
        {
            Autores autores = db.Autores1.Find(id);
            if (autores == null)
            {
                return NotFound();
            }

            db.Autores1.Remove(autores);
            db.SaveChanges();

            return Ok(autores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutoresExists(int id)
        {
            return db.Autores1.Count(e => e.id_autor == id) > 0;
        }
    }
}