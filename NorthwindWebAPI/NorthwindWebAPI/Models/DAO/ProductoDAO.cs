using NorthwindWebAPI.Models.VO;
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
                    QuantityPerUnit = c.QuantityPerUnit,
                    UnitPrice = c.UnitPrice

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

        public int modificarProductos(Products nuevosDatosProductos)
        {
            using (var cnn = new NorthwindEntities())
            {
                var anteriorProducto = cnn.Products.SingleOrDefault(c => c.ProductID.Equals(nuevosDatosProductos.ProductID));
                anteriorProducto.ProductName = nuevosDatosProductos.ProductName;
                anteriorProducto.QuantityPerUnit= nuevosDatosProductos.QuantityPerUnit;
                anteriorProducto.UnitPrice = nuevosDatosProductos.UnitPrice;
                cnn.Entry(anteriorProducto).State = System.Data.Entity.EntityState.Modified;
                return cnn.SaveChanges();
            }
        }
        /*public int EliminarProducto(object EliminarProducto)
        {
            using(var cnn=new NorthwindEntities())
            {
                var anteriorProducto = cnn.Products.SingleOrDefault(c => c.ProductID.Equals(EliminarProducto.ProductID));
                anteriorProducto.ProductName = EliminarProducto.ProductName;
                anteriorProducto.QuantityPerUnit = EliminarProducto.QuantityPerUnit;
                anteriorProducto.UnitPrice =EliminarProducto.UnitPrice;
                cnn.Entry(anteriorProducto).State = System.Data.Entity.EntityState.Deleted;
                return cnn.SaveChanges();
            }
        }*/
    }
}

