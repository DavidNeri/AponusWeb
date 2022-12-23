using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aponus_Web_API.Business
{
    public class BS_Products
            {
        private readonly AponusContext AponusDBContext;

       

        public BS_Products()
        {
            AponusDBContext = new AponusContext();
        }

        public JsonResult ProductsByProductName()
        {       

            var Products =AponusDBContext.ProductosDescripcions.Select(
               x => new ProductosDescripcion
               {
                   IdDescripcion=x.IdDescripcion,
                   DescripcionProducto = x.DescripcionProducto,
                   Productos = x.Productos
               }
               );


            return new JsonResult(Products);

        }

        public JsonResult ProductsByType(string typeId)
        {
            var Products = AponusDBContext.ProductosTipos
               .Select(
               x => new ProductosTipo
               {
                   IdTipo = x.IdTipo,
                   DescripcionTipo = x.DescripcionTipo,
                   Productos = x.Productos

               }                                  
               )
               .Where(x=>x.IdTipo==typeId);


            return new JsonResult(Products);

        }

    }
}
