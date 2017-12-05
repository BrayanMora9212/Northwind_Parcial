﻿using NorthwindWebAPI.Models;
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
    public class ProductosController : ApiController
    {
        [HttpGet]
        [Route("api/productos/consultar")]
        public List<ProductosVO> ConsultarProductos()
        {
            return new ProductoDAO().ConsultarProductos();
        }


        [HttpPost]
        [Route("api/Productos/registrar")]
        public string registrarProducto(FormDataCollection parametros)
        {
            var dao = new ProductoDAO();
            var nuevoProducto = new Products()
            {
                ProductID = int.Parse(parametros["ProductID"]),
                ProductName = parametros["ProductName"],    
                UnitsInStock = short.Parse(parametros["UnitsInStock"]),
                UnitPrice =  decimal.Parse(parametros["UnitPrice"])
              };
            int resultado = dao.registrarProducto(nuevoProducto);
            return (resultado > 0) ? "Se registró el producto" : "Ocurrió un error al registrar el producto ";
        }


        [HttpPut]
        [Route("api/categorias/modificar")]
        public string modificarCategoria(Categories categoria)
        {
            var dao = new CategoriaDAO();
            int resultado = dao.modificarCategoria(categoria);
            return (resultado > 0) ? "Se actualizó la categoría" : "Ocurrió un error al modificar la categoría";
        }



    }
}
