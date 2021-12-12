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
    public class InsertarUsuariosDTOController : ApiController
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
        }

        // POST api/Usuarios/InsertarUsuarios
        [HttpPost]
        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/InsertarUsuarios")]
        public IHttpActionResult InsertarUsuarios([FromBody] Usuarios usuario)
        {
            Console.Write(usuario);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Usuarios_INS_InsertarUsuario(usuario.dni, usuario.nombre, usuario.apellidos, usuario.direccion, usuario.telefono, usuario.email, usuario.usuario, usuario.password, usuario.admin, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // DELETE api/Usuarios/BorrarUsuarios
        [HttpGet]
        [ResponseType(typeof(String))]
        [Route("api/Usuarios/BorrarUsuarios/{dni}")]
        public IHttpActionResult BorrarUsuarios([FromBody] String dni)
        {
            Console.Write(dni);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Usuarios_DEL_BorrarUsuario(dni, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }
    }
}