using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}