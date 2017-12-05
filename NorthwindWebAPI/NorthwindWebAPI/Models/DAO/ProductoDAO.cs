﻿using NorthwindWebAPI.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindWebAPI.Models.DAO
{
    public class ProductoDAO
    {
        public List<ProductosVO> ConsultarProductos()
        {
            using (var cnn = new NorthwindEntities())
            {
                return cnn.Products.Select(c => new ProductosVO
                {

                    ProductID = c.ProductID,
                    ProductName = c.ProductName,
                    UnitsInStock = c.UnitsInStock,
                    UniPrice = c.UnitPrice

                }).ToList();
            }
        }

        public int registrarProducto(Products nuevoProducto)
        {
            using (var cnn = new NorthwindEntities())
            {
                cnn.Products.Add(nuevoProducto);
                return cnn.SaveChanges();
            }
        }

        internal int registrarProducto(object nuevoProducto)
        {
            throw new NotImplementedException();
        }
    }
}