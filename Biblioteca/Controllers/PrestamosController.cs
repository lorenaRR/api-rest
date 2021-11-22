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
    public class PrestamosController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Prestamos
        public IQueryable<Prestamos> GetPrestamos()
        {
            return db.Prestamos;
        }

        // GET: api/Prestamos/5
        [ResponseType(typeof(Prestamos))]
        public IHttpActionResult GetPrestamos(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return NotFound();
            }

            return Ok(prestamos);
        }

        // PUT: api/Prestamos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrestamos(int id, Prestamos prestamos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamos.id_prestamo)
            {
                return BadRequest();
            }

            db.Entry(prestamos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamosExists(id))
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

        // POST: api/Prestamos
        [ResponseType(typeof(Prestamos))]
        public IHttpActionResult PostPrestamos(Prestamos prestamos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestamos.Add(prestamos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PrestamosExists(prestamos.id_prestamo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prestamos.id_prestamo }, prestamos);
        }

        // DELETE: api/Prestamos/5
        [ResponseType(typeof(Prestamos))]
        public IHttpActionResult DeletePrestamos(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return NotFound();
            }

            db.Prestamos.Remove(prestamos);
            db.SaveChanges();

            return Ok(prestamos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestamosExists(int id)
        {
            return db.Prestamos.Count(e => e.id_prestamo == id) > 0;
        }
    }
}