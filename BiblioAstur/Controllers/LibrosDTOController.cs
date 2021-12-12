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
    
    public class LibrosDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/SeleccionarUsuariosDTO/5
        [ResponseType(typeof(SeleccionarLibrosDTO))]
        [HttpGet]
        [Route("api/Libros/SeleccionarLibros")]

        public IHttpActionResult SeleccionarLibros(string isbn, string titulo, string subtitulo, string editorial, string autor)

        {
            List<SeleccionarLibrosDTO> lista = null;


            if (isbn == null)
            {
                isbn = "";
            }
            if (titulo == null)
            {
                titulo = "";
            }
            if (subtitulo == null)
            {
                subtitulo = "";
            }
            if (editorial == null)
            {
                editorial = "";
            }
            if (autor == null)
            {
                autor = "";
            }


            lista = this.db.up_Libros_SEL_SeleccionarLibros(isbn, titulo, subtitulo, editorial, autor).ToList();

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