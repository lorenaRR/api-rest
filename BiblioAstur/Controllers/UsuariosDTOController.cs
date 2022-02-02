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
    public class UsuariosDTOController : ApiController
    {

        private BibliotecaEntities db = new BibliotecaEntities();
        public class Usuarios
        {
            public string nombre;
            public string apellidos;
            public string dni;
            public string direccion;
            public string telefono;
            public bool admin;
            public string email;
            public string usuario;
            public string password;
            public DateTime fechaNacimiento;
        }

        // GET: api/SeleccionarUsuariosDTO/5
        [ResponseType(typeof(SeleccionarUsuariosDTO))]
        [HttpGet]
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

        // PUT api/Usuarios/ActualizarUsuarios
        [HttpPut]
        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/ActualizarUsuarios")]
        public IHttpActionResult ActualizarUsuarios([FromBody] Usuarios usuario)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Usuarios_UPD_ActualizarUsuario(usuario.dni, usuario.nombre, usuario.apellidos, usuario.direccion, usuario.telefono, usuario.email, usuario.usuario, usuario.password, usuario.admin, usuario.fechaNacimiento, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // POST api/Usuarios/InsertarUsuarios
        [HttpPost]
        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/InsertarUsuarios")]
        public IHttpActionResult InsertarUsuarios([FromBody] Usuarios usuario)
        {
            usuario.usuario = usuario.dni;
            usuario.password = usuario.email;
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Usuarios_INS_InsertarUsuario(usuario.dni, usuario.nombre, usuario.apellidos, usuario.direccion, usuario.telefono, usuario.email, usuario.usuario, usuario.password, usuario.admin, usuario.fechaNacimiento, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // DELETE api/Usuarios/BorrarUsuarios
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Usuarios/BorrarUsuarios/{dni}")]
        public IHttpActionResult BorrarUsuarios(String dni)
        {
            Console.Write(dni);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Usuarios_DEL_BorrarUsuario(dni, estadoObjectParameter).FirstOrDefault().Value);
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