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
    public class BorrarUsuariosControllerDTO : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();


        // DELETE api/Usuarios/BorrarUsuarios
        /*[ResponseType(typeof(String))]
        [HttpPost]
        [Route("api/Usuarios/BorrarUsuarios")]
        public IHttpActionResult BorrarUsuarios([FromBody] String dni)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Usuarios_DEL_BorrarUsuario(dni, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }*/
    }
}