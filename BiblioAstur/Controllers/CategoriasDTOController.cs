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

    public class CategoriasDTOController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        public class Categorias
        {
            public Guid id_categoria;
            public string categoria;
        }

        public class CategoriasLibro
        {
            public Guid id;
            public Guid id_categoria;
            public string isbn;
        }


        // GET: api/Categorias/SeleccionarCategorias
        [ResponseType(typeof(SeleccionarCategoriasDTO))]
        [HttpGet]
        [Route("api/Categorias/SeleccionarCategorias")]

        public IHttpActionResult SeleccionarCategorias()

        {
            List<SeleccionarCategoriasDTO> lista = null;


            lista = this.db.up_Categorias_SEL_SeleccionarCategorias().ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // POST api/Categorias/InsertarCategorias
        [HttpPost]
        [ResponseType(typeof(Categorias))]
        [Route("api/Categorias/InsertarCategorias")]
        public IHttpActionResult InsertarCategorias([FromBody] Categorias categoria)
        {
            Console.Write(categoria);
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Categorias_INS_InsertarCategoria(categoria.categoria, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }

        // POST api/Categorias/InsertarCategoriasLibro
        [HttpPost]
        [ResponseType(typeof(CategoriasLibro))]
        [Route("api/Categorias/InsertarCategoriasLibro")]
        public IHttpActionResult InsertarCategoriasLibro([FromBody] CategoriasLibro categoria_libro)
        {
            Console.Write(categoria_libro);

            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Categorias_Libros_INS_InsertarCategoriaLibro(categoria_libro.id_categoria, categoria_libro.isbn, estadoObjectParameter).FirstOrDefault().Value);
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