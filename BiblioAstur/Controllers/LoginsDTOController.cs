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
    public class LoginsDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();
        // GET: api/SeleccionarCategorias
        [ResponseType(typeof(LoginsDTO))]
        [HttpGet]
        [Route("api/Usuarios/Logins")]

        public IHttpActionResult Logins(string user, string pass)

        {
            List<LoginsDTO> lista = null;

            lista = this.db.up_Usuarios_SEL_Logins(user, pass).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }
    }
}