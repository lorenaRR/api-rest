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
    public class AutoresDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        public class Autores
        {
            public Guid id;
            public string nombre;
            public string apellidos;
        }

        public class AutoresLibro
        {
            public Guid id;
            public Guid id_autor;
            public string isbn;
        }

        //**************************AUTORES************************

        // GET: api/Autores/SeleccionarAutores
        [ResponseType(typeof(SeleccionarAutoresDTO))]
        [HttpGet]
        [Route("api/Autores/SeleccionarAutores")]

        public IHttpActionResult SeleccionarAutores(string id_autor, string nombre, string apellidos)

        {
            List<SeleccionarAutoresDTO> lista = null;

            if (id_autor == null)
            {
                id_autor = "";
            }

            if (nombre==null)
            {
                nombre = "";
            }

            if (apellidos == null)
            {
                apellidos = "";
            }

            lista = this.db.up_Autores_SEL_SeleccionarAutores(id_autor,nombre,apellidos).ToList();

            /*if (lista.Count == 0)
            {
                return NotFound();
            }*/

            return Ok(lista);

        }

        // POST api/Usuarios/InsertarAutores
        [HttpPost]
        [ResponseType(typeof(Autores))]
        [Route("api/Autores/InsertarAutores")]
        public IHttpActionResult InsertarAutores([FromBody] Autores autor)
        {
            Console.Write(autor);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Autores_INS_InsertarAutor(autor.nombre, autor.apellidos, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // DELETE api/Autores/BorrarAutores
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Autores/BorrarAutores/{id_autor}")]
        public IHttpActionResult BorrarAutores(String id_autor)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Autores_DEL_BorrarAutor(id_autor, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        //**************************AUTORES-LIBRO************************


        // GET: api/Autores/SeleccionarAutoresLibro
        [ResponseType(typeof(SeleccionarAutoresLibroDTO))]
        [HttpGet]
        [Route("api/Autores/SeleccionarAutoresLibro")]

        public IHttpActionResult SeleccionarAutoresLibro(string isbn, string id_autor)

        {
            List<SeleccionarAutoresLibroDTO> lista = null;


            if (isbn == null)
            {
                isbn = "";
            }

            if (id_autor == null)
            {
                id_autor = "";
            }

            lista = this.db.up_Autores_Libros_SEL_SeleccionarAutoresLibro(isbn,id_autor).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // GET: api/Autores/SeleccionarAutoresLibroUncampo
        [ResponseType(typeof(SeleccionarAutoresLibroDTO))]
        [HttpGet]
        [Route("api/Autores/SeleccionarAutoresLibroUnCampo")]

        public IHttpActionResult SeleccionarAutoresLibroUnCampo(string autor)

        {
            List<SeleccionarAutoresUnCampoDTO> lista = null;


            if (autor == null)
            {
                autor = "";
            }


            lista = this.db.up_Autores_SEL_SeleccionarAutoresUnCampo(autor).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // POST api/Autores/InsertarAutoresLibro
        [HttpPost]
        [ResponseType(typeof(AutoresLibro))]
        [Route("api/Autores/InsertarAutoresLibro")]
        public IHttpActionResult InsertarAutoresLibro([FromBody] AutoresLibro autor_libro)
        {
            Console.Write(autor_libro);

            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Autores_Libros_INS_InsertarAutorLibro(autor_libro.id_autor, autor_libro.isbn, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // DELETE api/Autores/BorrarAutoresLibros
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Autores/BorrarAutoresLibros")]
        public IHttpActionResult BorrarAutoresLibros(String id_autor, String isbn)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Autores_Libros_DEL_BorrarAutorLibro(id_autor, isbn, estadoObjectParameter).FirstOrDefault().Value);
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