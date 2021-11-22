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
    public class Categorias_LibrosController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Categorias_Libros
        public IQueryable<Categorias_Libros> GetCategorias_Libros()
        {
            return db.Categorias_Libros;
        }

        // GET: api/Categorias_Libros/5
        [ResponseType(typeof(Categorias_Libros))]
        public IHttpActionResult GetCategorias_Libros(int id)
        {
            Categorias_Libros categorias_Libros = db.Categorias_Libros.Find(id);
            if (categorias_Libros == null)
            {
                return NotFound();
            }

            return Ok(categorias_Libros);
        }

        // PUT: api/Categorias_Libros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorias_Libros(int id, Categorias_Libros categorias_Libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorias_Libros.id_categorias_libros)
            {
                return BadRequest();
            }

            db.Entry(categorias_Libros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Categorias_LibrosExists(id))
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

        // POST: api/Categorias_Libros
        [ResponseType(typeof(Categorias_Libros))]
        public IHttpActionResult PostCategorias_Libros(Categorias_Libros categorias_Libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorias_Libros.Add(categorias_Libros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Categorias_LibrosExists(categorias_Libros.id_categorias_libros))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categorias_Libros.id_categorias_libros }, categorias_Libros);
        }

        // DELETE: api/Categorias_Libros/5
        [ResponseType(typeof(Categorias_Libros))]
        public IHttpActionResult DeleteCategorias_Libros(int id)
        {
            Categorias_Libros categorias_Libros = db.Categorias_Libros.Find(id);
            if (categorias_Libros == null)
            {
                return NotFound();
            }

            db.Categorias_Libros.Remove(categorias_Libros);
            db.SaveChanges();

            return Ok(categorias_Libros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Categorias_LibrosExists(int id)
        {
            return db.Categorias_Libros.Count(e => e.id_categorias_libros == id) > 0;
        }
    }
}