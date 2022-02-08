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
    public class PrestamosDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        public class Prestamos
        {
            public Guid id;
            public string isbn;
            public string dni;
            public DateTime fechaPrestamo;
            public DateTime fechaEntrega;
            public DateTime fechaDevolucion;
            public DateTime fechaInvalida;
        }
        // GET: api/Autores/SeleccionarPrestamos
        [ResponseType(typeof(SeleccionarPrestamosDTO))]
        [HttpGet]
        [Route("api/Prestamos/SeleccionarPrestamos")]

        public IHttpActionResult SeleccionarPrestamos(string isbn, string dni)

        {
            List<SeleccionarPrestamosDTO> lista = null;


            if (isbn == null)
            {
                isbn = "";
            }

            if (dni == null)
            {
                dni = "";
            }

            lista = this.db.up_Prestamos_SEL_SeleccionarPrestamos(isbn, dni).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // GET: api/Autores/SeleccionarPrestamosUsuarios
        [ResponseType(typeof(SeleccionarPrestamosUsuariosDTO))]
        [HttpGet]
        [Route("api/Prestamos/SeleccionarPrestamosUsuarios")]

        public IHttpActionResult SeleccionarPrestamosUsuarios(string dni)

        {
            List<SeleccionarPrestamosUsuariosDTO> lista = null;

            if (dni == null)
            {
                dni = "";
            }

            lista = this.db.up_Prestamos_SEL_SeleccionarPrestamosUsuarios(dni).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // GET: api/Autores/SeleccionarNoDevueltos
        [ResponseType(typeof(SeleccionarLibrosNoDevueltosDTO))]
        [HttpGet]
        [Route("api/Prestamos/SeleccionarNoDevueltos")]

        public IHttpActionResult SeleccionarLibrosNoDevueltos()

        {
            List<SeleccionarLibrosNoDevueltosDTO> lista = null;


            lista = this.db.up_Prestamos_SEL_SeleccionarLibrosNoDevueltos().ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // POST api/Prestamos/InsertarPrestamos
        [HttpPost]
        [ResponseType(typeof(Prestamos))]
        [Route("api/Prestamos/InsertarPrestamos")]
        public IHttpActionResult InsertarAutoresLibro([FromBody] Prestamos prestamo)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Prestamos_INS_InsertarPrestamo(prestamo.isbn, prestamo.dni, prestamo.fechaPrestamo, prestamo.fechaEntrega, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // PUT api/Prestamos/ActualizarPrestamos
        [HttpPut]
        [ResponseType(typeof(Prestamos))]
        [Route("api/Prestamos/ActualizarPrestamos")]
        public IHttpActionResult ActualizarPrestamos([FromBody] Prestamos prestamo)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Prestamos_UPD_ActualizarPrestamos(prestamo.isbn, prestamo.dni, prestamo.fechaPrestamo, prestamo.fechaEntrega, prestamo.fechaDevolucion, estadoObjectParameter).FirstOrDefault().Value);
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