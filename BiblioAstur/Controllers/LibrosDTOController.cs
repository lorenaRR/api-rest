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
            public bool reservado;
            public bool prestado;
        }


        // GET: api/SeleccionarLibros
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
            respuesta.Resultado = Convert.ToBoolean(db.up_Libros_INS_InsertarLibro(libro.isbn, libro.titulo, libro.subtitulo, libro.fechaPublicacion, libro.descripcion, libro.nPaginas, libro.imagen, libro.editorial, libro.stock, libro.reservado, libro.prestado, estadoObjectParameter).FirstOrDefault().Value);
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