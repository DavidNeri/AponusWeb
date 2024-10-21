using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Aponus_Web_API.Acceso_a_Datos.Productos
{
    public class ObtenerProductos
    {
        private readonly AponusContext AponusDBContext;
        public ObtenerProductos(AponusContext AponusContext)
        {
            AponusDBContext = AponusContext;
        }
        public JsonResult Listar()
        {

            var Products = AponusDBContext.ProductosDescripcions
                .Select(x => new ProductosDescripcion
                {
                   IdDescripcion = x.IdDescripcion,
                   DescripcionProducto = x.DescripcionProducto,
                   Productos = x.Productos.Select(P => new Producto()
                   {
                       Cantidad = P.Cantidad,
                   }).ToList(),
                });
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
                                .Where(x => x.IdTipo.Contains(typeId ?? ""))
                                .OrderBy(x => x.DiametroNominal)

               }
               ).AsEnumerable() 
               .Where(x => x.Productos.Count > 0);

            return new JsonResult(Products);

        }
        public JsonResult Listar(string? typeId, int? IdDescription)
        {     

            try
            {
                var Products = AponusDBContext.ProductosDescripcions
                    .Select(x => new ProductosDescripcion
                    {
                        DescripcionProducto = x.DescripcionProducto,
                        Productos = (ICollection<Producto>)x.Productos
                                                            .Where(x => x.IdTipo == typeId && x.IdDescripcion==IdDescription)
                                                            .OrderBy(x => x.DiametroNominal)
                    }).AsEnumerable()
                    .Where(x => x.Productos.Count > 0);

                return new JsonResult(Products);

            }
            catch (DbException e)
            {
                return new JsonResult(e.Message);
            }

        }
        public JsonResult Listar(string? typeId, int? IdDescription, int?Dn)
        {
            try
            {

                var Products = AponusDBContext.ProductosDescripcions
              .Select(
              x => new ProductosDescripcion
              {
                  DescripcionProducto = x.DescripcionProducto,

                  Productos = (ICollection<Producto>)x.Productos
                               .Where(x => x.IdTipo == typeId && x.IdDescripcion == IdDescription&&x.DiametroNominal==Dn)
                               .OrderBy(x => x.DiametroNominal)

              }
              ).AsEnumerable()
              .Where(x => x.Productos.Count > 0);

                return new JsonResult(Products);


            }
            catch (DbException e)
            {

                return new JsonResult(e.Message);
            }

        }
        public async Task<JsonResult> ListarDN(string typeId)
        {
            var DN = await AponusDBContext.Productos
                .Where(x => x.IdTipo == typeId)
                .Select(x => x.DiametroNominal)
                .Distinct().ToListAsync();

            return new JsonResult(DN);
        }
        internal async Task<JsonResult> ListarDN(string? typeId, int? idDescription)
        {
            var DN = await AponusDBContext.Productos
                .Where(x => x.IdTipo == typeId && x.IdDescripcion==idDescription)
                .Select(x => x.DiametroNominal)
                .Distinct().ToListAsync();

            return new JsonResult(DN);
        }
    }
}
