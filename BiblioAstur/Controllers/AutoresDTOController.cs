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

        // GET: api/Autores/SeleccionarAutores
        [ResponseType(typeof(SeleccionarAutoresDTO))]
        [HttpGet]
        [Route("api/Autores/SeleccionarAutores")]

        public IHttpActionResult SeleccionarAutores(string nombre, string apellidos)

        {
            List<SeleccionarAutoresDTO> lista = null;

            if (nombre==null)
            {
                nombre = "";
            }

            if (apellidos == null)
            {
                apellidos = "";
            }

            lista = this.db.up_Autores_SEL_SeleccionarAutores(nombre,apellidos).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        /*// PUT api/Usuarios/ActualizarUsuarios
        [HttpPut]
        [ResponseType(typeof(Autores))]
        [Route("api/Usuarios/ActualizarAutores")]
        public IHttpActionResult ActualizarUsuarios([FromBody] Autores autor)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Autores_UPD_ActualizarAutores(autor.id, autor.nombre, autor.apellidos, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }*/

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
        




        // POST api/Usuarios/InsertarAutoresLibro
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

        public class ResultadoDTO
        {
            public bool Resultado { get; set; }
            public string Estado { get; set; }
        }

    }
}