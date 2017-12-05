using NorthwindWebAPI.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindWebAPI.Models.DAO
{
    public class CategoriaDAO
    {

        public List<CategoriaVO> consultarCategorias()
        {
            using (var cnn = new NorthwindEntities())
            {
                return cnn.Categories.Select(c => new CategoriaVO
                {

                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description

                }).ToList();
            }
        }


        public int registrarCategoria(Categories nuevaCategoria) {
            using (var cnn = new NorthwindEntities())
            {
                cnn.Categories.Add(nuevaCategoria);
                return cnn.SaveChanges();
            }
        }


        public int modificarCategoria(Categories nuevosDatosCategoria) {
            using (var cnn = new NorthwindEntities())
            {
                var anteriorCategoria = cnn.Categories.SingleOrDefault(c => c.CategoryID.Equals(nuevosDatosCategoria.CategoryID));
                anteriorCategoria.CategoryName = nuevosDatosCategoria.CategoryName;
                anteriorCategoria.Description = nuevosDatosCategoria.Description;
                cnn.Entry(anteriorCategoria).State = System.Data.Entity.EntityState.Modified;
                return cnn.SaveChanges();
            }
        }



    }
}