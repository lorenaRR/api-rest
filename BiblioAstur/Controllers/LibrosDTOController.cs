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

        public class Libros
        {
            public string isbn;
            public string titulo;
            public string subtitulo;
            public DateTime fechaPublicacion;
            public string descripcion;
            public int nPaginas;
            public string imagen;
            public string editorial;
            public int stock;
        }

        // GET: api/SeleccionarLibros
        [ResponseType(typeof(SeleccionarLibrosDTO))]
        [HttpGet]
        [Route("api/Libros/SeleccionarLibros")]

        public IHttpActionResult SeleccionarLibros(string isbn, string titulo, string subtitulo, string editorial)

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



            lista = this.db.up_Libros_SEL_SeleccionarLibros(isbn, titulo, subtitulo, editorial).ToList();


            return Ok(lista);

        }

        // GET: api/Libros/SeleccionarCatalogo
        [ResponseType(typeof(SeleccionarCatalogoDTO))]
        [HttpGet]
        [Route("api/Libros/SeleccionarCatalogo")]

        public IHttpActionResult SeleccionarCatalogo(string isbn, string titulo, string subtitulo, string editorial, string autor, string categoria)

        {
            List<SeleccionarCatalogoDTO> lista = null;


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
            if (categoria == null)
            {
                categoria = "";
            }


            lista = this.db.up_Libros_SEL_SeleccionarCatalogo(isbn, titulo, subtitulo, editorial, autor, categoria).ToList();

            return Ok(lista);

        }

        // GET: api/SeleccionarLibros
        [ResponseType(typeof(SeleccionarNumLectoresDTO))]
        [HttpGet]
        [Route("api/Libros/SeleccionarNumLectores")]

        public IHttpActionResult SeleccionarNumLectores()

        {
            List<SeleccionarNumLectoresDTO> lista = null;



            lista = this.db.up_Libros_SEL_SeleccionarNumLectores().ToList();

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

        // PUT api/Libros/ActualizarLibros
        [HttpPut]
        [ResponseType(typeof(Libros))]
        [Route("api/Libros/ActualizarLibros")]
        public IHttpActionResult ActualizarLibros([FromBody] Libros libro)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Libros_UPD_ActualizarLibro(libro.isbn, libro.titulo, libro.subtitulo, libro.fechaPublicacion, libro.descripcion, libro.nPaginas, libro.imagen, libro.editorial, libro.stock, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // POST api/Libros/InsertarLibros
        [HttpPost]
        [ResponseType(typeof(Libros))]
        [Route("api/Libros/InsertarLibros")]
        public IHttpActionResult InsertarLibros([FromBody] Libros libro)
        {
            Console.Write(libro);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Libros_INS_InsertarLibro(libro.isbn, libro.titulo, libro.subtitulo, libro.fechaPublicacion, libro.descripcion, libro.nPaginas, libro.imagen, libro.editorial, libro.stock, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // DELETE api/Libros/BorrarLibro
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Libros/BorrarLibro/{isbn}")]
        public IHttpActionResult BorrarLibro(String isbn)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Libros_DEL_BorrarLibro(isbn, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        public class ResultadoDTO
        {
            public bool Resultado { get; set; }
            public string Estado { get; set; }
        }
    }
}