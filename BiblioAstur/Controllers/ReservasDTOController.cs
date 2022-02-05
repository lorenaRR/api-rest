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
    public class ReservasDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        public class Reservas
        {
            public Guid id;
            public string dni;
            public string isbn;
            public DateTime fecha_reserva;
        }

        // GET: api/Reservas/SeleccionarReserva
        [ResponseType(typeof(SeleccionarReservasDTO))]
        [HttpGet]
        [Route("api/Reservas/SeleccionarReservas")]

        public IHttpActionResult SeleccionarReservas(string dni, string isbn)

        {
            List<SeleccionarReservasDTO> lista = null;

            if (dni == null)
            {
                dni = "";
            }

            if (isbn == null)
            {
                isbn = "";
            }

            lista = this.db.up_Reservas_SEL_SeleccionarReservas(dni, isbn).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // GET: api/Reservas/SeleccionarReservaUsuarios
        [ResponseType(typeof(SeleccionarReservasUsuariosDTO))]
        [HttpGet]
        [Route("api/Reservas/SeleccionarReservasUsuarios")]

        public IHttpActionResult SeleccionarReservasUsuarios(string dni, string isbn, string titulo)

        {
            List<SeleccionarReservasUsuariosDTO> lista = null;

            if (dni == null)
            {
                dni = "";
            }

            if (isbn == null)
            {
                isbn = "";
            }

            if (titulo == null)
            {
                titulo = "";
            }

            lista = this.db.up_Reservas_SEL_SeleccionarReservasUsuarios(dni, isbn, titulo).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }


        // POST api/Reservas/InsertarReserva
        [HttpPost]
        [ResponseType(typeof(Reservas))]
        [Route("api/Reservas/InsertarReserva")]
        public IHttpActionResult InsertarReserva([FromBody] Reservas reserva)
        {

            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Reservas_INS_InsertarReserva(reserva.isbn, reserva.dni, reserva.fecha_reserva, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // DELETE api/Reservas/BorrarReserva
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Reservas/BorrarReserva")]
        public IHttpActionResult BorrarReserva(String isbn, String dni)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Reservas_DEL_BorrarReserva(isbn, dni, estadoObjectParameter).FirstOrDefault().Value);
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