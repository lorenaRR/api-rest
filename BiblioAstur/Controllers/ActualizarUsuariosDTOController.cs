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
    public class ActualizarUsuariosDTOController : ApiController
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

        // PUT api/Usuarios/ActualizarUsuarios
        [HttpPut]
        [ResponseType(typeof(Usuarios))]
        [Route("api/Usuarios/ActualizarUsuarios")]
        public IHttpActionResult ActualizarUsuarios([FromBody] Usuarios usuario)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db. up_Usuarios_UPD_ActualizarUsuario(usuario.dni, usuario.nombre, usuario.apellidos, usuario.direccion, usuario.telefono, usuario.email, usuario.usuario, usuario.password, usuario.admin, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }
    }
}