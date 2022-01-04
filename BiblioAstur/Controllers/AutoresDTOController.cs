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


        // GET: api/Autores/SeleccionarAutores
        [ResponseType(typeof(SeleccionarAutoresDTO))]
        [HttpGet]
        [Route("api/Autores/SeleccionarAutores")]

        public IHttpActionResult SeleccionarAutores()

        {
            List<SeleccionarAutoresDTO> lista = null;

            lista = this.db.up_Autores_SEL_SeleccionarAutores().ToList();

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
        [Route("api/Usuarios/InsertarAutores")]
        public IHttpActionResult InsertarUsuarios([FromBody] Autores autor)
        {
            Console.Write(autor);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Autores_INS_InsertarAutor(autor.id, autor.nombre, autor.apellidos, estadoObjectParameter).FirstOrDefault().Value);
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