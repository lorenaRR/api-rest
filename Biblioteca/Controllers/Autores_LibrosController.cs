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
    public class Autores_LibrosController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Autores_Libros
        public IQueryable<Autores_Libros> GetAutores_Libros()
        {
            return db.Autores_Libros;
        }

        // GET: api/Autores_Libros/5
        [ResponseType(typeof(Autores_Libros))]
        public IHttpActionResult GetAutores_Libros(int id)
        {
            Autores_Libros autores_Libros = db.Autores_Libros.Find(id);
            if (autores_Libros == null)
            {
                return NotFound();
            }

            return Ok(autores_Libros);
        }

        // PUT: api/Autores_Libros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutores_Libros(int id, Autores_Libros autores_Libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autores_Libros.id_autores_libros)
            {
                return BadRequest();
            }

            db.Entry(autores_Libros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Autores_LibrosExists(id))
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

        // POST: api/Autores_Libros
        [ResponseType(typeof(Autores_Libros))]
        public IHttpActionResult PostAutores_Libros(Autores_Libros autores_Libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Autores_Libros.Add(autores_Libros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Autores_LibrosExists(autores_Libros.id_autores_libros))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autores_Libros.id_autores_libros }, autores_Libros);
        }

        // DELETE: api/Autores_Libros/5
        [ResponseType(typeof(Autores_Libros))]
        public IHttpActionResult DeleteAutores_Libros(int id)
        {
            Autores_Libros autores_Libros = db.Autores_Libros.Find(id);
            if (autores_Libros == null)
            {
                return NotFound();
            }

            db.Autores_Libros.Remove(autores_Libros);
            db.SaveChanges();

            return Ok(autores_Libros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Autores_LibrosExists(int id)
        {
            return db.Autores_Libros.Count(e => e.id_autores_libros == id) > 0;
        }
    }
}