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
        // GET: api/SeleccionarCategorias
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
    }
}