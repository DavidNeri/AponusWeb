using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Aponus_Web_API.Acceso_a_Datos.Sistema

{
    public class Categorias
    {
        private readonly AponusContext AponusDBContext;
        public Categorias() { AponusDBContext = new AponusContext(); }

        internal List<DTODescripciones> ListarDescripciones(string idTipo)
        {
            List<DTODescripciones> Descripciones = AponusDBContext.ProductosDescripcions
                .Join(AponusDBContext.Producto_Tipo_Descripcion,
                _Descripciones => _Descripciones.IdDescripcion, _Tipo => _Tipo.IdDescripcion,
                (_Descripciones, _Tipo) => new {
                    _idTipo = _Tipo.IdTipo,
                    _Descripciones.IdDescripcion,
                    _Descripciones.DescripcionProducto
                })
                .Where(Tipo => Tipo._idTipo == idTipo)
                .Select(x => new DTODescripciones { IdDescripcion = x.IdDescripcion, Descripcion = x.DescripcionProducto })
                .ToList();

            return Descripciones;

        }

        internal int NuevaDescripcion(DTOCategorias nuevaCategoria)
        {
            try
            {
                AponusDBContext.ProductosDescripcions
                               .Add(new ProductosDescripcion
                               {
                                   DescripcionProducto = nuevaCategoria.Descripcion.ToUpper() 
                               }) ;

                AponusDBContext.SaveChanges();
                

                int? IdDescripcionNullable = AponusDBContext.ProductosDescripcions
                    .Where(x => x.DescripcionProducto == nuevaCategoria.Descripcion)
                    .Select(x => x.IdDescripcion).FirstOrDefault();

                int IdDescripcion = IdDescripcionNullable ?? 0;


                 return IdDescripcion;
                
            }
            catch (SqlException ex)
            {
                return 0;

            }
           

        }

        internal void NuevoTipo(DTOCategorias NuevaCategoria)
        {
         
                AponusDBContext.ProductosTipos.
                Add(new ProductosTipo
                {
                    IdTipo = NuevaCategoria.IdTipo,
                    DescripcionTipo = NuevaCategoria.DescripcionTipo
                });

                AponusDBContext.SaveChanges();

        }

        internal ProductosTipo? ObtenerTipo(ProductosTipo productosTipo)
        {
            ProductosTipo? TipoAnteriorExiste = AponusDBContext.ProductosTipos
                .Where(T=>T.IdTipo==productosTipo.IdTipo)
                .Select(x=>new ProductosTipo()
                {
                    IdTipo=x.IdTipo,
                    DescripcionTipo=x.DescripcionTipo,
                }).FirstOrDefault();

            return TipoAnteriorExiste;
        }

        public void VincularCategorias(DTOCategorias nuevaCategoria)
        {
            AponusDBContext.Producto_Tipo_Descripcion
                .Add(new Productos_Tipos_Descripcion
                {
                    IdTipo = nuevaCategoria.IdTipo,
                    IdDescripcion = nuevaCategoria.IdDescripcion,
                });
            AponusDBContext.SaveChanges();

        }

        internal void ActualizarTipoProd(DTOActualizarCategorias actualizarCategorias)
        {
            ProductosTipo? TipoAnterior = AponusDBContext.ProductosTipos.FirstOrDefault(T => T.IdTipo == actualizarCategorias.Anterior.IdTipo);

            if (TipoAnterior !=null)
            {
                TipoAnterior.DescripcionTipo = actualizarCategorias.Nueva.DescripcionTipo;
                TipoAnterior.IdTipo = actualizarCategorias.Nueva.IdTipo;
                AponusDBContext.SaveChanges();
                   
            }

        }

        internal void ActualizarDescripcionProd(DTOActualizarCategorias actualizarCategorias)
        {
            ProductosDescripcion? DescripcionAnterior = AponusDBContext.ProductosDescripcions
                .FirstOrDefault(PD => PD.IdDescripcion == actualizarCategorias.Anterior.IdDescripcion);

            if (DescripcionAnterior!=null)
            {
                DescripcionAnterior.DescripcionProducto = actualizarCategorias.Nueva.Descripcion;
                AponusDBContext.SaveChanges();
            }
        }

        internal void ActualizarTipos_Descripciones(DTOActualizarCategorias actualizarCategorias)
        {
            Productos_Tipos_Descripcion? RelacionAnterior = AponusDBContext.Producto_Tipo_Descripcion
                 .FirstOrDefault(TD => TD.IdTipo == actualizarCategorias.Anterior.IdTipo && TD.IdDescripcion == actualizarCategorias.Anterior.IdDescripcion);

            if (RelacionAnterior!=null)
            {
                RelacionAnterior.IdTipo = actualizarCategorias.Nueva.IdTipo;
                AponusDBContext.SaveChanges();

            }
        }

        internal IActionResult AgregarDescripcionCompoente(string descripcionComponente)
        {
            

            try
            {
                var Exists = AponusDBContext.ComponentesDescripcions
                .FirstOrDefault(
                x => x.Descripcion.Trim().ToUpper() == descripcionComponente.Trim().ToUpper()
                );
                if (Exists == null)
                {
                    AponusDBContext.ComponentesDescripcions.Add(new ComponentesDescripcion() { Descripcion = descripcionComponente.Trim().ToUpper(), });
                    AponusDBContext.SaveChanges();
                    return new StatusCodeResult(200);

                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "El nombre del componente ya existe",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {

                if (ex.InnerException != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                };
            }catch(Exception ex) 
            {
                if (ex.InnerException != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                };
            }

           
            

            

                
        }

        internal IActionResult ModificarDescripcionComponente(DTODescripcionComponentes descripcion)
        {
            try
            {
                AponusDBContext.ComponentesDescripcions.Update(new ComponentesDescripcion()
                {
                    IdDescripcion = descripcion.IdDescripcion,
                    Descripcion = descripcion.Descripcion.Trim().ToUpper(),
                });
                AponusDBContext.SaveChanges();

                return new StatusCodeResult(200);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {

                if (ex.InnerException != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                };
            }

        }

        public class Productos
        {
            
            public IActionResult EliminarTipo(string IdTipo)
            {
                Categorias categorias= new Categorias();
                try
                {
                    //Busar el Id Tipo
                    ProductosTipo? TipoProdEliminar = categorias.AponusDBContext.ProductosTipos
                        .FirstOrDefault(x => x.IdTipo == IdTipo);

                    //Cambiar el estado del  Id Tipo a INACTIVO
                    if (TipoProdEliminar != null)
                    {
                        TipoProdEliminar.IdEstado = Convert.ToInt32("0x00", 16);
                        categorias.AponusDBContext.ProductosTipos.Update(TipoProdEliminar);
                    }

                    //Buscar los Id Descripcion relacionados al IdDescripcion
                    var IdDescripcionesEliminar = categorias.AponusDBContext.Producto_Tipo_Descripcion
                        .Where(x => x.IdTipo.Equals(IdTipo))
                        .Select(x => x.IdDescripcion)
                        .ToList();

                    //Con los Id Descripcion buscar la Lista de 'DescrpcionTìpo' relacionados (al IdDescripcion)
                    List<ProductosDescripcion>? DescripcionProdEliminar = categorias.AponusDBContext.ProductosDescripcions
                        .Where(x => IdDescripcionesEliminar.Contains(x.IdDescripcion))
                        .ToList();

                    if (DescripcionProdEliminar != null)
                    {
                        DescripcionProdEliminar?.ForEach(x => x.IdEstado = Convert.ToInt32("0x00", 16));
                        categorias.AponusDBContext.ProductosDescripcions.UpdateRange(DescripcionProdEliminar);

                        List<(string IdTIpo, int IdDescripcion)> ListaCategoriasProductos = DescripcionProdEliminar
                            .Select(x => (IdTipo, x.IdDescripcion)).ToList();

                        //Busco Los PRODUCTOS que pertenicen a esas duplas IdDescripcion/IDdescripcion
                        List<Producto>? Productos = categorias.AponusDBContext.Productos
                            .Where(x => ListaCategoriasProductos.Any(Lista => Lista.IdTIpo == x.IdTipo && Lista.IdDescripcion == x.IdDescripcion))
                            .Select(P => new Producto()
                            {
                                Cantidad = P.Cantidad,
                                IdDescripcion = P.IdDescripcion,
                                IdEstado = Convert.ToInt32("0x00", 16),
                                IdTipo = P.IdTipo,
                                DiametroNominal = P.DiametroNominal,
                                IdProducto = P.IdProducto,
                                PrecioFinal = P.PrecioFinal,
                                Tolerancia = P.Tolerancia,
                                PrecioLista = P.PrecioLista,
                                PorcentajeGanancia = P.PorcentajeGanancia,

                            }).ToList();

                        //Cambio el estado a INACTIVO
                        categorias.AponusDBContext.Productos.UpdateRange(Productos);

                    }

                    //Guardo los cambios en la DB
                    using (var Transaccion = categorias.AponusDBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            categorias.AponusDBContext.SaveChanges();
                            Transaccion.Commit();
                            return new StatusCodeResult(200);
                        }
                        catch (Exception ex)
                        {
                            string? ContenidoSalida = "No se aplicaron los cambios:\n";
                            Transaccion.Rollback();

                            ContentResult Salida = new ContentResult()
                            {
                                ContentType = "application/json",
                                StatusCode = 400,
                            };

                            ContenidoSalida = ex.InnerException.Message != null ? ContenidoSalida.Concat(ex.InnerException.Message).ToString() : ContenidoSalida.Concat(ex.Message).ToString();
                            Salida.Content = ContenidoSalida;

                            return Salida;
                        }
                    }
                }
                catch (Exception ex)
                {

                    string? ContenidoSalida = "No se aplicaron los cambios:\n";

                    ContentResult Salida = new ContentResult()
                    {
                        ContentType = "application/json",
                        StatusCode = 400,
                    };

                    ContenidoSalida = ex.InnerException.Message != null ? ContenidoSalida.Concat(ex.InnerException.Message).ToString() : ContenidoSalida.Concat(ex.Message).ToString();
                    Salida.Content = ContenidoSalida;

                    return Salida;
                }

            }

            internal IActionResult EliminarDescripcion(int IdDescripcion)
            {
                Categorias categorias = new Categorias();
                try
                {
                    //Busar el IdDescripcion
                    ProductosDescripcion? IdDescripcionEliminar = categorias.AponusDBContext.ProductosDescripcions
                        .FirstOrDefault(x => x.IdDescripcion == IdDescripcion);

                    //Cambiar el estado del IdDescripcion INACTIVO
                    if (IdDescripcionEliminar != null)
                    {
                        IdDescripcionEliminar.IdEstado = Convert.ToInt32("0x00", 16);
                        categorias.AponusDBContext.ProductosDescripcions.Update(IdDescripcionEliminar);

                        //Busco Los PRODUCTOS relacioandos 
                        List<Producto>? Productos = categorias.AponusDBContext.Productos
                            .Where(x =>x.IdDescripcion == IdDescripcion)
                            .Select(P => new Producto()
                            {
                                Cantidad = P.Cantidad,
                                IdDescripcion = P.IdDescripcion,
                                IdEstado = Convert.ToInt32("0x00", 16),
                                IdTipo = P.IdTipo,
                                DiametroNominal = P.DiametroNominal,
                                IdProducto = P.IdProducto,
                                PrecioFinal = P.PrecioFinal,
                                Tolerancia = P.Tolerancia,
                                PrecioLista = P.PrecioLista,
                                PorcentajeGanancia = P.PorcentajeGanancia,

                            }).ToList();

                        // Cambio el estado de los PRODUCTOS a INACTIVO
                        if(Productos.Count>0)categorias.AponusDBContext.Productos.UpdateRange(Productos) ;

                    }

                    //Guardo los cambios en la DB
                    using (var Transaccion = categorias.AponusDBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            categorias.AponusDBContext.SaveChanges();
                            Transaccion.Commit();
                            return new StatusCodeResult(200);
                        }
                        catch (Exception ex)
                        {
                            string? ContenidoSalida = "No se aplicaron los cambios:\n";
                            Transaccion.Rollback();

                            ContentResult Salida = new ContentResult()
                            {
                                ContentType = "application/json",
                                StatusCode = 400,
                            };

                            ContenidoSalida = ex.InnerException.Message != null ? ContenidoSalida.Concat(ex.InnerException.Message).ToString() : ContenidoSalida.Concat(ex.Message).ToString();
                            Salida.Content = ContenidoSalida;

                            return Salida;
                        }
                    }
                }
                catch (Exception ex)
                {

                    string? ContenidoSalida = "No se aplicaron los cambios:\n";

                    ContentResult Salida = new ContentResult()
                    {
                        ContentType = "application/json",
                        StatusCode = 400,
                    };

                    ContenidoSalida = ex.InnerException.Message != null ? ContenidoSalida.Concat(ex.InnerException.Message).ToString() : ContenidoSalida.Concat(ex.Message).ToString();
                    Salida.Content = ContenidoSalida;

                    return Salida;
                }
            }
        }
    }
}
