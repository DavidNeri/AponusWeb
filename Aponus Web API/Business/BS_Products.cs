using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.Build.Framework;

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

        public JsonResult ProductsByType(string? typeId)
        {
            var Products = AponusDBContext.ProductosDescripcions
               .Select(
               x => new ProductosDescripcion
               {
                   IdDescripcion = x.IdDescripcion,
                   DescripcionProducto = x.DescripcionProducto,
                   Productos = (ICollection<Producto>)x.Productos
                                .Where(x => x.IdTipo == typeId)
                                .OrderBy(x => x.DiametroNominal)

               }
               ).AsEnumerable()
               .Where(x => x.Productos.Count > 0);
              

         


            return new JsonResult(Products);

        }

        internal JsonResult ListParts(string? productId) {


           // var InsumosProductos = AponusDBContext.ComponentesPesables
                //                   .Include(C1 => C1..Select(x => x.Altura))
                //                   .Include(C2=>C2.)
                                   

                  //                 .Select(x => x.Descripcion);



            /*
            var InsumosProducto = AponusDBContext.ComponentesDescripcions.Select(x => new InsumosProducto()
            {
                Insumo = x.Descripcion,
                Medida = (IEnumerable<decimal>)x.PesablesDetalles.Select(x => x.Diametro),

            }).Where<ComponentesPesable>(x=> x.);
            
           */

            return null;
            

        }
    }
}
