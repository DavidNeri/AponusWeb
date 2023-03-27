using Aponus_Web_API.Business;
using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Aponus_Web_API.Data_Transfer_objects;



namespace Aponus_Web_API.Acceso_a_Datos.Productos
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
        public async Task<DatosProducto> Listar(string? typeId, int? DN)
        {
            try
            {


                var _DatosProducto = AponusDBContext.Productos
                            .Join(AponusDBContext.ProductosDescripcions,
                            _Productos => _Productos.IdDescripcion,
                            _ProductosDescripcion => _ProductosDescripcion.IdDescripcion,
                            (_Productos, _ProductosDescripcion) => new
                            {
                                _Productos.IdTipo,
                                _Productos.DiametroNominal,
                                _ProductosDescripcion.DescripcionProducto

                            })
                            .Where(x => x.IdTipo == typeId && x.DiametroNominal == DN)
                            .OrderBy(x => x.DescripcionProducto)
                            .Select(x => new
                            {
                                Descripcion = x.DescripcionProducto

                            })
                            .Distinct()
                            .Single();
                List<EspecificacionesDatosProducto> _EspecificacionesProducto = await AponusDBContext.Productos
                               .Where(x => x.IdTipo == typeId && x.DiametroNominal == DN)

                               .Select(x => new EspecificacionesDatosProducto()
                               {
                                   IdProducto = x.IdProducto,
                                   DiametroNominal = x.DiametroNominal,
                                   Tolerancia=x.Tolerancia,
                                   Cantidad = x.Cantidad

                               }).ToListAsync();
                _EspecificacionesProducto.OrderBy(X => X.DiametroNominal).ThenBy(x => x.Tolerancia);

                DatosProducto _Producto = new DatosProducto()
                {
                    DescripcionProducto = _DatosProducto.Descripcion.ToString(),
                    Producto = _EspecificacionesProducto

                };

                _Producto.Producto = _EspecificacionesProducto;


                return _Producto;
            }
            catch (Exception)
            {

                throw;
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
    }
}