using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
namespace Aponus_Web_API.Services
{
    public class ObtenerProductos
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerProductos() { AponusDBContext = new AponusContext(); }
        public JsonResult Listar()
        {

            var Products = AponusDBContext.ProductosDescripcions.Select(
               x => new ProductosDescripcion
               {
                   IdDescripcion = x.IdDescripcion,
                   DescripcionProducto = x.DescripcionProducto,
                   Productos = x.Productos
               }
               );


            return new JsonResult(Products);

        }

        public JsonResult Listar(string? typeId)
        {
            var Products = AponusDBContext.ProductosDescripcions
               .Select(
               x => new ProductosDescripcion
               {
                   DescripcionProducto = x.DescripcionProducto,

                   Productos = (ICollection<Producto>)x.Productos
                                .Where(x => x.IdTipo == typeId)
                                .OrderBy(x => x.DiametroNominal)

               }
               ).AsEnumerable()
               .Where(x => x.Productos.Count > 0);

            return new JsonResult(Products);

        }

    }
}
