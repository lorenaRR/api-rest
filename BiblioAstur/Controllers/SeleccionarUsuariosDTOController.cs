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
using BiblioAstur;

namespace BiblioAstur.Controllers
{
    public class SeleccionarUsuariosDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/SeleccionarUsuariosDTO
        public IQueryable<SeleccionarUsuariosDTO> GetSeleccionarUsuariosDTOes()
        {
            return db.SeleccionarUsuariosDTOes;
        }

        // GET: api/SeleccionarUsuariosDTO/5

        [ResponseType(typeof(SeleccionarUsuariosDTO))]
        [HttpGet]
        //[ResponseType(typeof(List<SeleccionarUsuariosDTO>))]
        [Route("api/Usuarios/SeleccionarUsuarios")]

        public IHttpActionResult SeleccionarUsuarios(string id, byte admin, string nombre, string apellidos)

        {
            List<SeleccionarUsuariosDTO> lista = null;


            if (id == null)
            {
                id = "";
            }
            if (nombre == null)
            {
                nombre = "";
            }
            if (apellidos == null)
            {
                apellidos = "";
            }



            lista = this.db.up_Usuarios_SEL_SeleccionarUsuarios(id, admin, nombre, apellidos).ToList();


            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // PUT: api/SeleccionarUsuariosDTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeleccionarUsuariosDTO(string id, SeleccionarUsuariosDTO seleccionarUsuariosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seleccionarUsuariosDTO.dni)
            {
                return BadRequest();
            }

            db.Entry(seleccionarUsuariosDTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeleccionarUsuariosDTOExists(id))
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

        // POST: api/SeleccionarUsuariosDTO
        [ResponseType(typeof(SeleccionarUsuariosDTO))]
        public IHttpActionResult PostSeleccionarUsuariosDTO(SeleccionarUsuariosDTO seleccionarUsuariosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SeleccionarUsuariosDTOes.Add(seleccionarUsuariosDTO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SeleccionarUsuariosDTOExists(seleccionarUsuariosDTO.dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seleccionarUsuariosDTO.dni }, seleccionarUsuariosDTO);
        }

        // DELETE: api/SeleccionarUsuariosDTO/5
        [ResponseType(typeof(SeleccionarUsuariosDTO))]
        public IHttpActionResult DeleteSeleccionarUsuariosDTO(string id)
        {
            SeleccionarUsuariosDTO seleccionarUsuariosDTO = db.SeleccionarUsuariosDTOes.Find(id);
            if (seleccionarUsuariosDTO == null)
            {
                return NotFound();
            }

            db.SeleccionarUsuariosDTOes.Remove(seleccionarUsuariosDTO);
            db.SaveChanges();

            return Ok(seleccionarUsuariosDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeleccionarUsuariosDTOExists(string id)
        {
            return db.SeleccionarUsuariosDTOes.Count(e => e.dni == id) > 0;
        }
    }
}