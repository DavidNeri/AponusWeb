using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Z.EntityFramework.Plus;

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

        internal async Task<Exception?> ActualizarPrecioProducto(Producto producto)
        {           
            try
            {
                var Existente = AponusDBContext.Productos
               .Where(x => x.IdProducto == producto.IdProducto)
               .First();

                if (Existente != null)
                {
                    Existente.PrecioLista = producto.PrecioLista;
                    producto.PrecioFinal = producto.PrecioFinal;
                    AponusDBContext.Productos.Update(Existente);
                    AponusDBContext.Entry(Existente).State = EntityState.Modified;
                    await AponusDBContext.SaveChangesAsync();
                }

                return null;
            }
            catch (Exception ex)
            {

                return ex;
            }

        }

        internal void GuardarProducto(DTOProducto producto)
        {
            //AGregar NuevoAcceso Producto 
            AponusDBContext.Productos.Add(new Producto
            {
                IdProducto = producto.IdProducto ?? "",
                IdDescripcion = producto.IdDescripcion ?? 0,
                IdTipo = producto.IdTipo ?? "",
                DiametroNominal = producto.DiametroNominal,
                Cantidad = Convert.ToInt32(producto.Cantidad),
                PrecioLista = producto.PrecioLista,
                Tolerancia = producto.Tolerancia,
                IdEstado = 1,
                IdEstadoNavigation = AponusDBContext.EstadosProducto.First(x => x.IdEstado == 1),
                IdDescripcionNavigation = AponusDBContext.ProductosDescripcions.First(x => x.IdDescripcion == producto.IdDescripcion),
                IdTipoNavigation = AponusDBContext.ProductosTipos.First(x => x.IdTipo == producto.IdTipo),
                PrecioFinal = producto.PrecioFinal,
                PorcentajeGanancia = producto.PorcentajeGanancia ?? producto.PrecioFinal ?? 0 - producto.PrecioLista ?? 0

            });

            // ProcesarDatos los cambios en la base de datos
            AponusDBContext.SaveChanges();
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
        internal void HabilitarProducto(Producto Producto)
        {
            Producto.IdEstadoNavigation = AponusDBContext.EstadosProducto.FirstOrDefault(x => x.IdEstado == 1) ?? new EstadosProductos();
            Producto.IdDescripcionNavigation = AponusDBContext.ProductosDescripcions.FirstOrDefault(x => x.IdDescripcion == Producto.IdDescripcion) ?? new ProductosDescripcion();
            Producto.IdTipoNavigation = AponusDBContext.ProductosTipos.FirstOrDefault(x => x.IdTipo == Producto.IdTipo) ?? new ProductosTipo();

            AponusDBContext.Productos.Update(Producto);

            var Componentes = AponusDBContext.Componentes_Productos
                .Where(x => x.IdProducto.Equals(Producto.IdProducto))
                .ToList();

            if (Componentes.Any())
                AponusDBContext.Componentes_Productos.RemoveRange(Componentes);

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
        internal void EliminarComponentesProducto(string IdProducto)
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
        public List<ProductosDescripcion> Listar()
        {

            var Products = AponusDBContext.ProductosDescripcions
                .Where(x => x.IdEstado != 0)
                .Select(x => new ProductosDescripcion
                {
                    IdDescripcion = x.IdDescripcion,
                    DescripcionProducto = x.DescripcionProducto,
                    Productos = x.Productos.Where(x => x.IdEstado != 0)
                    .Select(P => new Producto()
                    {
                        Cantidad = P.Cantidad,
                        DiametroNominal = P.DiametroNominal,
                        IdDescripcion = P.IdDescripcion,
                        IdProducto = P.IdProducto,
                        IdTipo = P.IdTipo,
                        PrecioFinal = P.PrecioFinal,
                        PrecioLista = P.PrecioLista,
                        Tolerancia = P.Tolerancia,
                        PorcentajeGanancia = P.PorcentajeGanancia,
                        IdDescripcionNavigation = P.IdDescripcionNavigation,
                        IdTipoNavigation = P.IdTipoNavigation,


                    }).ToList(),
                })
                .ToList();

            return Products;
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
                    .Select(x => new
                    {
                        DescripcionProducto = x.DescripcionProducto,
                        Productos = x.Productos
                            .Where(y => (typeId == null || y.IdTipo == typeId) && (IdDescription == null || y.IdDescripcion == IdDescription) && y.IdEstado != 0)
                            .Select(producto => new
                            {
                                nombre = $"{x.DescripcionProducto} DN:{producto.DiametroNominal} Tolerancia:{producto.Tolerancia}",
                                producto.IdProducto,
                                producto.DiametroNominal,
                                producto.IdDescripcion,
                                producto.IdTipo,
                                producto.Tolerancia,
                                producto.Cantidad,
                                producto.PrecioFinal,
                                producto.PrecioLista,
                                producto.PorcentajeGanancia,
                            })
                            .OrderBy(x => x.DiametroNominal)
                            .ToList()
                    })
                    .Where(x => x.Productos.Count > 0)
                    .ToList();



                return new JsonResult(Products);

            }
            catch (DbException e)
            {
                return new JsonResult(e.Message);
            }

        }
        //public JsonResult Listar(string? typeId, int? IdDescription, int? Dn)
        //{
        //    try
        //    {

        //        var Products = AponusDBContext.ProductosDescripcions
        //      .Select(
        //      x => new ProductosDescripcion
        //      {
        //          DescripcionProducto = x.DescripcionProducto,

        //          Productos = (ICollection<Producto>)x.Productos
        //                       .Where(x => x.IdTipo == typeId && x.IdDescripcion == IdDescription && x.DiametroNominal == Dn)
        //                       .ToList()
        //                       .OrderBy(x => x.DiametroNominal)


        //      }
        //      ).AsEnumerable()
        //      .Where(x => x.Productos.Count > 0);

        //        return new JsonResult(Products.ToList());


        //    }
        //    catch (DbException e)
        //    {

        //        return new JsonResult(e.Message);
        //    }

        //}
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

        internal List<DTOProducto> ListarProdVentas(List<string>? IdProductos)
        {
            List<DTOProducto> Products = AponusDBContext.Productos
                .Join(AponusDBContext.ProductosDescripcions, Prod => Prod.IdDescripcion, Desc => Desc.IdDescripcion, (prod, Desc) => new
                {
                    prod,
                    Desc
                })
                .Where(x => (IdProductos == null || IdProductos.Contains(x.prod.IdProducto)) && x.prod.IdEstado != 0)
                .Select(x => new DTOProducto
                {
                    Nombre = $"{x.Desc.DescripcionProducto} DN:{x.prod.DiametroNominal} Tolerancia:{x.prod.Tolerancia}",
                    IdProducto = x.prod.IdProducto,
                    DiametroNominal = x.prod.DiametroNominal,
                    IdDescripcion = x.prod.IdDescripcion,
                    IdTipo = x.prod.IdTipo,
                    Tolerancia = x.prod.Tolerancia,
                    Cantidad = x.prod.Cantidad,
                    PrecioFinal = x.prod.PrecioFinal,
                    PrecioLista = x.prod.PrecioLista,
                    PorcentajeGanancia = x.prod.PorcentajeGanancia,
                    Componentes = null
                })
                .ToList();
            return Products;

        }

        internal async Task<Exception?> DeshabilitarProducto(Producto producto)
        {
            try
            {
                producto.IdEstado = 0;
                var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
                producto.IdEstadoNavigation = AponusDBContext.EstadosProducto.First(x => x.IdEstado == 0);
                AponusDBContext.Entry(producto).State = EntityState.Modified;
                await AponusDBContext.SaveChangesAsync();
                await transaccion.CommitAsync();

                return null;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
