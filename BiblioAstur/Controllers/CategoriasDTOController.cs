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


        //***************************CATEGORIAS****************************


        // GET: api/Categorias/SeleccionarCategorias
        [ResponseType(typeof(SeleccionarCategoriasDTO))]
        [HttpGet]
        [Route("api/Categorias/SeleccionarCategorias")]

        public IHttpActionResult SeleccionarCategorias(string id_categoria, string categoria)

        {
            List<SeleccionarCategoriasDTO> lista = null;

            if (id_categoria == null)
            {
                id_categoria = "";
            }

            if (categoria == null)
            {
                categoria = "";
            }

            lista = this.db.up_Categorias_SEL_SeleccionarCategorias(id_categoria,categoria).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // GET: api/Categorias/SeleccionarNumLibrosPorCategorias
        [ResponseType(typeof(SeleccionarNumLibrosPorCategoriasDTO))]
        [HttpGet]
        [Route("api/Categorias/SeleccionarNumLibrosPorCategorias")]

        public IHttpActionResult SeleccionarNumLibrosPorCategorias()

        {
            List<SeleccionarNumLibrosPorCategoriasDTO> lista = null;

            lista = this.db.up_Categorias_SEL_SeleccionarNumLibrosPorCategorias().ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // GET: api/Categorias/SeleccionarNumUsuariosPorCategorias
        [ResponseType(typeof(SeleccionarNumUsuariosPorCategoriasDTO))]
        [HttpGet]
        [Route("api/Categorias/SeleccionarNumUsuariosPorCategorias")]

        public IHttpActionResult SeleccionarNumUsuariosPorCategorias()

        {
            List<SeleccionarNumUsuariosPorCategoriasDTO> lista = null;

            lista = this.db.up_Categorias_SEL_SeleccionarNumUsuariosPorCategorias().ToList();

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

        // DELETE api/Categorias/BorrarCategorias
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Categorias/BorrarCategorias/{id_categoria}")]
        public IHttpActionResult BorrarCategorias(String id_categoria)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Categorias_DEL_BorrarCategoria(id_categoria, estadoObjectParameter).FirstOrDefault().Value);
            respuesta.Estado = estadoObjectParameter.Value.ToString();
            return Ok(respuesta);
        }



        //***************************CATEGORIAS-LIBRO****************************


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

        // GET: api/Categorias/SeleccionarCategoriasLibro
        [ResponseType(typeof(ListaCategoriasLibroDTO))]
        [HttpGet]
        [Route("api/Categorias/SeleccionarCategoriasLibro")]

        public IHttpActionResult SeleccionarCategoriasLibro(String isbn, String id_categoria)

        {
            List<SeleccionarCategoriaLibroDTO> lista = null;

            if (isbn == null)
            {
                isbn = "";
            }
            if (id_categoria == null)
            {
                id_categoria = "";
            }


            lista = this.db.up_Categorias_Libros_SEL_SeleccionarCategoriaLibro(isbn, id_categoria).ToList();

            if (lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);

        }

        // DELETE api/Categorias/BorrarCategoriasLibros
        [HttpDelete]
        [ResponseType(typeof(String))]
        [Route("api/Categorias/BorrarCategoriasLibros")]
        public IHttpActionResult BorrarCategoriasLibros(String id_categoria, String isbn)
        {
            ResultadoDTO respuesta = new ResultadoDTO();
            ObjectParameter estadoObjectParameter = new ObjectParameter("estado", typeof(String));
            respuesta.Resultado = Convert.ToBoolean(db.up_Categorias_Libros_DEL_BorrarCategoriaLibro(id_categoria,isbn, estadoObjectParameter).FirstOrDefault().Value);
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