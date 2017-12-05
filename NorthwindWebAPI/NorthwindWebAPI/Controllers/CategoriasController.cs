using NorthwindWebAPI.Models;
using NorthwindWebAPI.Models.DAO;
using NorthwindWebAPI.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace NorthwindWebAPI.Controllers
{
    public class CategoriasController : ApiController
    {

        [HttpGet]
        [Route("api/categorias/consultar")]
        public List<CategoriaVO> ConsultarCategorias() {
            return new CategoriaDAO().consultarCategorias();
        }


        [HttpPost]
        [Route("api/categorias/registrar")]
        public string registrarCategoria(FormDataCollection parametros) {
            var dao = new CategoriaDAO();
            var nuevaCategoria = new Categories() {
                CategoryName = parametros["CategoryName"],
                Description = parametros["Description"]
            };
            int resultado = dao.registrarCategoria(nuevaCategoria);
            return (resultado > 0) ? "Se registró la categoría" : "Ocurrió un error al registrar la categoría";
        }


        [HttpPut]
        [Route("api/categorias/modificar")]
        public string modificarCategoria(Categories categoria) {
            var dao = new CategoriaDAO();
            int resultado = dao.modificarCategoria(categoria);
            return (resultado > 0) ? "Se actualizó la categoría" : "Ocurrió un error al modificar la categoría";
        }



    }
}
