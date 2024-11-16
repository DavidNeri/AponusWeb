using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Productos
    {
        private readonly AponusContext AponusDBContext;
        private readonly AD_Componentes componentesProductos;
        public AD_Productos(AponusContext _aponusDbContext, AD_Componentes _componentesProductos)
        {
            AponusDBContext = _aponusDbContext;
            componentesProductos = _componentesProductos;
        }
        internal void GuardarProducto(DTOProducto producto)
        {
            //AGregar Nuevo Producto 
            AponusDBContext.Productos.Add(new Producto
            {
                IdProducto = producto.IdProducto ?? "",
                IdDescripcion = producto.IdDescripcion ?? 0,
                IdTipo = producto.IdTipo ?? "",
                DiametroNominal = producto.DiametroNominal,
                Cantidad = Convert.ToInt32(producto.Cantidad),
                PrecioLista = producto.PrecioLista,
                Tolerancia = producto.Tolerancia
            });

            // ProcesarDatos los cambios en la base de datos
            AponusDBContext.SaveChanges();
        }
        public string GenerarIdProd(DTOProducto Producto)
        {
            string IdProducto;

            try
            {
                string Tolerancia = Producto.Tolerancia ?? "".Replace("-", "_").Replace("/", "_");
                IdProducto = $"{Producto.IdTipo}_{Producto.IdDescripcion}_{Producto.DiametroNominal}_{Producto.Tolerancia}";

            }
            catch (Exception)
            {

                return "";
            }

            return IdProducto;
        }
        internal void GuardarComponentes(List<DTOComponentesProducto> Componentes)
        {
            bool ChkIdProd = Componentes.All(x => x.IdProducto != null);

            if (ChkIdProd)
            {
                foreach (DTOComponentesProducto Componente in Componentes)
                {
                    try
                    {
                        if (Componente.IdProducto != null && Componente.IdComponente != null) { }
                        {
                            componentesProductos.GuardarComponenteProd(new Productos_Componentes
                            {
                                IdProducto = Componente.IdProducto!,
                                IdComponente = Componente.IdComponente!,
                                Cantidad = Componente.Cantidad,
                                Longitud = Componente.Largo,
                                Peso = Componente.Peso,
                            });
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                AponusDBContext.SaveChanges();
            }

        }
        public Producto? BuscarProducto(string Id_Producto)
        {
            return AponusDBContext.Productos
                .Where(x => x.IdProducto == Id_Producto)
                .Select(x => new Producto()
                {
                    IdProducto = x.IdProducto,
                    IdDescripcion = x.IdDescripcion,
                    IdTipo = x.IdTipo,
                    DiametroNominal = x.DiametroNominal,
                    Tolerancia = x.Tolerancia,
                    Cantidad = x.Cantidad,
                    PrecioFinal = x.PrecioFinal,
                    PrecioLista = x.PrecioLista,
                    PorcentajeGanancia = x.PorcentajeGanancia,

                }).SingleOrDefault();
        }
        internal void ModifyProductDetails(Producto ProductUpdate)
        {
            AponusDBContext.Entry(ProductUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            AponusDBContext.SaveChanges();
        }
        internal string? ObtenerValor(string prop, string IdProducto)
        {

            var Valor = AponusDBContext.Productos
                .Where(x => x.IdProducto == IdProducto)
                .Select(x => x.GetType().GetProperty(prop).GetValue(x))
                .FirstOrDefault();

            if (Valor != null)
            {
                return Valor.ToString();

            }
            else
            {
                return null;
            }

        }
        internal void DeleteAllProductComponents(string IdProducto)
        {
            var DeleteComponents = AponusDBContext.Componentes_Productos.Where(x => x.IdProducto == IdProducto).ToArray();
            if (DeleteComponents != null)
            {
                AponusDBContext.Componentes_Productos.RemoveRange(DeleteComponents);
                AponusDBContext.SaveChanges();
            }
        }
        internal void AgregarComponente(Productos_Componentes NewComponent)
        {
            AponusDBContext.Componentes_Productos.Add(NewComponent);
            AponusDBContext.SaveChanges();
        }
        internal void ModifyProductComponents(List<Productos_Componentes> ProducComponentsUpdate)
        {
            AponusDBContext.Componentes_Productos.UpdateRange(ProducComponentsUpdate);
            AponusDBContext.SaveChanges();
        }
        internal void ActualizarIdProd(string idAnterior, string nuevoId)
        {
            AponusDBContext.Productos.Where(x => x.IdProducto == idAnterior).UpdateFromQuery(x => new Producto { IdProducto = nuevoId });
            AponusDBContext.SaveChanges();
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
                                                            .Where(x => x.IdTipo == typeId && x.IdDescripcion == IdDescription)
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
        public JsonResult Listar(string? typeId, int? IdDescription, int? Dn)
        {
            try
            {

                var Products = AponusDBContext.ProductosDescripcions
              .Select(
              x => new ProductosDescripcion
              {
                  DescripcionProducto = x.DescripcionProducto,

                  Productos = (ICollection<Producto>)x.Productos
                               .Where(x => x.IdTipo == typeId && x.IdDescripcion == IdDescription && x.DiametroNominal == Dn)
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
                .Where(x => x.IdTipo == typeId && x.IdDescripcion == idDescription)
                .Select(x => x.DiametroNominal)
                .Distinct().ToListAsync();

            return new JsonResult(DN);
        }
    }
}
