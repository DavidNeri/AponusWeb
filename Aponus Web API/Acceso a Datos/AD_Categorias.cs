using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Categorias
    {
        private readonly AponusContext AponusDBContext;
        public AD_Categorias(AponusContext _AponusContext)
        {
            AponusDBContext = _AponusContext;
        }
        public Productos MetodosProductos()
        {
            return new Productos(AponusDBContext);
        }

        internal (List<ProductosDescripcion>? Listado, Exception? Error) ListarDescripcionesProductos(string? idTipo)
        {
            try
            {
                return
                    (
                        AponusDBContext.ProductosDescripcions.Join(AponusDBContext.Producto_Tipo_Descripcion,
                        _Descripciones => _Descripciones.IdDescripcion,
                        _Tipo => _Tipo.IdDescripcion,
                        (_Descripciones, _Tipo) => new
                        {
                            _idTipo = _Tipo.IdTipo,
                            _Descripciones.IdDescripcion,
                            _Descripciones.DescripcionProducto

                        }).Where(Tipo => Tipo._idTipo == idTipo || string.IsNullOrEmpty(idTipo))
                        .Select(x => new ProductosDescripcion()
                        {
                            IdDescripcion = x.IdDescripcion,
                            DescripcionProducto = x.DescripcionProducto
                        })
                        .ToList(),
                        null
                    );
            }
            catch (Exception error)
            {
                return (null, error);
            }
        }
        internal async Task<(int? Resultado, Exception? Error)> AgregarDescripcionProducto(ProductosDescripcion Categoria, string IdTipo)
        {
            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                AponusDBContext.ProductosDescripcions.Add(new ProductosDescripcion
                {
                    DescripcionProducto = Categoria.DescripcionProducto,
                    IdEstadoNavigation = await AponusDBContext.EstadosProductosDescripcione.FirstOrDefaultAsync(X => X.IdEstado == 1) ?? new EstadosProductosDescripciones()

                });

                await AponusDBContext.SaveChangesAsync();

                int? IdDescripcion = AponusDBContext.ProductosDescripcions
                        .Where(x => x.DescripcionProducto == Categoria.DescripcionProducto)
                        .Select(x => x.IdDescripcion).FirstOrDefault();

                if (IdDescripcion != null && !string.IsNullOrEmpty(IdTipo))
                {
                    AponusDBContext.Producto_Tipo_Descripcion.Add(new Productos_Tipos_Descripcion()
                    {
                        IdDescripcion = IdDescripcion,
                        IdTipo = IdTipo,
                        IdDescripcionNavigation = AponusDBContext.ProductosDescripcions.First(x => x.IdDescripcion == IdDescripcion),
                        IdTipoNavigation = AponusDBContext.ProductosTipos.First(x => x.IdTipo.Equals(IdTipo))
                    });

                    AponusDBContext.SaveChanges();
                    await transaccion.CommitAsync();

                    return (StatusCodes.Status200OK, null);
                }
                else
                {
                    await transaccion.RollbackAsync();
                    return (null, new Exception("Error interno,no se aplicaron los cambios"));
                }
            }
            catch (Exception error)
            {
                await transaccion.CommitAsync();
                return (null, error);

            }

        }
        internal void AgregarTipoProducto(DTOCategorias NuevaCategoria)
        {
            AponusDBContext.ProductosTipos.
            Add(new ProductosTipo
            {
                IdTipo = NuevaCategoria.IdTipo ?? "",
                DescripcionTipo = NuevaCategoria.DescripcionTipo,
                IdEstado = 1,
                IdEstadoNavigation = AponusDBContext.EstadosTiposProducto.First(x => x.IdEstado == 1)
            });

            AponusDBContext.SaveChanges();
        }
        internal ProductosTipo? ObtenerTipo(string IdTipo)
        {
            ProductosTipo? TipoAnteriorExiste = AponusDBContext.ProductosTipos
                .Where(T => T.IdTipo.Equals(IdTipo))
                .Select(x => new ProductosTipo()
                {
                    IdTipo = x.IdTipo,
                    DescripcionTipo = x.DescripcionTipo,
                }).FirstOrDefault();

            return TipoAnteriorExiste;
        }
        internal void ActualizarTipoProd(DTOActualizarCategorias actualizarCategorias)
        {
            if (actualizarCategorias.Anterior != null)
            {
                ProductosTipo? TipoAnterior = AponusDBContext.ProductosTipos.FirstOrDefault(T => T.IdTipo == actualizarCategorias.Anterior.IdTipo);

                if (TipoAnterior != null)
                {
                    TipoAnterior.DescripcionTipo = actualizarCategorias.Nueva?.DescripcionTipo;

                    if (TipoAnterior.IdTipo != actualizarCategorias?.Nueva?.IdTipo && actualizarCategorias?.Nueva?.IdTipo != null)
                    {
                        string idTipo = actualizarCategorias.Nueva.IdTipo;
                        string _idTipo = TipoAnterior.IdTipo;
                        AponusDBContext.Database.ExecuteSqlInterpolated($"UPDATE \"PRODUCTOS_TIPOS\" SET \"ID_TIPO\" = {idTipo} WHERE \"ID_TIPO\" = {_idTipo}");
                        AponusDBContext.ChangeTracker.Clear();
                    }

                    AponusDBContext.SaveChanges();
                }
            }
        }
        internal void ActualizarDescripcionProd(DTOActualizarCategorias actualizarCategorias)
        {
            if (actualizarCategorias.Anterior != null)
            {
                ProductosDescripcion? DescripcionAnterior = AponusDBContext.ProductosDescripcions.FirstOrDefault(PD => PD.IdDescripcion == actualizarCategorias.Anterior.IdDescripcion);

                if (DescripcionAnterior != null)
                {
                    DescripcionAnterior.DescripcionProducto = actualizarCategorias.Nueva?.Descripcion;
                    AponusDBContext.SaveChanges();
                }
            }
        }
        internal void ActualizarTipos_Descripciones(DTOActualizarCategorias actualizarCategorias)
        {

            if (actualizarCategorias.Anterior != null)
            {
                Productos_Tipos_Descripcion? RelacionAnterior = AponusDBContext.Producto_Tipo_Descripcion
                    .FirstOrDefault(TD => TD.IdTipo == actualizarCategorias.Anterior.IdTipo && TD.IdDescripcion == actualizarCategorias.Anterior.IdDescripcion);

                if (RelacionAnterior != null && actualizarCategorias.Nueva != null)
                {
                    RelacionAnterior.IdTipo = actualizarCategorias.Nueva.IdTipo ?? "";
                    AponusDBContext.SaveChanges();
                }
            }
        }
        internal async Task<(int?, Exception?)> AgregarDescripcionCompoente(ComponentesDescripcion Componente)
        {

            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                var Exists = AponusDBContext.ComponentesDescripcions
                    .First(x => x.Descripcion == null || x.Descripcion.Equals(Componente.Descripcion));

                if (Exists == null)
                {
                    await AponusDBContext.ComponentesDescripcions.AddAsync(Componente);
                    await AponusDBContext.SaveChangesAsync();
                    await transaccion.CommitAsync();

                    return (StatusCodes.Status200OK, null);

                }
                else
                {
                    return (null, new Exception("El nombre del componente ya existe"));
                }
            }
            catch (Exception error)
            {
                return (null, error);
            }
        }
        internal async Task<(int? StatusCode, Exception? Error)> ModificarDescripcionComponente(ComponentesDescripcion descripcion)
        {
            using var transaccion = await AponusDBContext.Database.BeginTransactionAsync();
            try
            {
                AponusDBContext.ComponentesDescripcions.Update(descripcion);
                await AponusDBContext.SaveChangesAsync();
                await transaccion.CommitAsync();

                return (StatusCodes.Status200OK, null);
            }
            catch (Exception error)
            {
                await transaccion.RollbackAsync();
                return (null, error);
            }
        }

        internal async Task<(int? Resultado, Exception? Error)> CambiarEstadoDescripcionComponentes(int idDescripcion)
        {
            try
            {
                List<ComponentesDescripcion> Listado = await AponusDBContext.ComponentesDescripcions
                    .Where(x => x.IdDescripcion == idDescripcion)
                    .ToListAsync();
                return (null, null);
                //Listado.ForEach(x => x.ide
            }
            catch (Exception)
            {

                throw;
            }
        }

        public class Productos
        {
            private readonly AponusContext AponusDBContext;

            public Productos(AponusContext aponusDBContext)
            {
                AponusDBContext = aponusDBContext;
            }

            internal List<ProductosTipo>? ListarTiposProductos()
            {
                List<ProductosTipo>? TipoProductos = AponusDBContext.ProductosTipos
                   .OrderBy(x => x.DescripcionTipo)
                   .Where(x => x.IdEstado != 0)
                   .Select(x => new ProductosTipo()
                   {
                       IdTipo = x.IdTipo,
                       DescripcionTipo = x.DescripcionTipo,
                       IdEstado = x.IdEstado,
                   })
                   .ToList();

                return TipoProductos;
            }

            public async Task<(int? resultado, Exception? error)> DesactivarTipoProductoyRelaciones(ProductosTipo TipoProducto)
            {
                var Transaccion = await AponusDBContext.Database.BeginTransactionAsync();
                try
                {
                    AponusDBContext.ProductosTipos.Update(TipoProducto);

                    //Buscar los Id NombreDescripcion relacionados al IdDescripcion
                    var IdDescripcionesEliminar = await AponusDBContext.Producto_Tipo_Descripcion
                        .Where(x => x.IdTipo.Equals(TipoProducto.IdTipo))
                        .Select(x => x.IdDescripcion)
                        .ToListAsync();

                    //Con los Id NombreDescripcion buscar la Lista de 'DescrpcionTìpo' relacionados (al IdDescripcion)
                    List<ProductosDescripcion>? DescripcionProdEliminar = await AponusDBContext.ProductosDescripcions
                        .Where(x => IdDescripcionesEliminar.Contains(x.IdDescripcion))
                        .ToListAsync();

                    if (DescripcionProdEliminar != null)
                    {
                        DescripcionProdEliminar?.ForEach(x => x.IdEstado = 0);
                        AponusDBContext.ProductosDescripcions.UpdateRange(DescripcionProdEliminar ?? Enumerable.Empty<ProductosDescripcion>());

                        if (DescripcionProdEliminar != null)
                        {
                            List<(string IdTIpo, int IdDescripcion)> ListaCategoriasProductos = DescripcionProdEliminar.Select(x => (TipoProducto.IdTipo, x.IdDescripcion)).ToList();

                            //Busco Los PRODUCTOS que pertenicen a esas duplas IdDescripcion/IDdescripcion
                            List<Producto>? Productos = AponusDBContext.Productos
                                .Where(x => x.IdTipoNavigation == TipoProducto)
                                .Select(P => new Producto()
                                {
                                    Cantidad = P.Cantidad,
                                    IdDescripcion = P.IdDescripcion,
                                    IdEstado = P.IdEstado,
                                    IdTipo = P.IdTipo,
                                    DiametroNominal = P.DiametroNominal,
                                    IdProducto = P.IdProducto,
                                    PrecioFinal = P.PrecioFinal,
                                    Tolerancia = P.Tolerancia,
                                    PrecioLista = P.PrecioLista,
                                    PorcentajeGanancia = P.PorcentajeGanancia,
                                    IdDescripcionNavigation = P.IdDescripcionNavigation,
                                    IdEstadoNavigation = P.IdEstadoNavigation,
                                    IdTipoNavigation = P.IdTipoNavigation,

                                }).ToList();

                            //Cambio el estado a INACTIVO

                            Productos.ForEach(Producto =>
                            {
                                Producto.IdEstado = 0;
                                Producto.IdEstadoNavigation = AponusDBContext.EstadosProducto.First(y => y.IdEstado == 0);
                                AponusDBContext.Entry(Producto).State = EntityState.Modified;

                            });


                            await AponusDBContext.SaveChangesAsync();
                            await Transaccion.CommitAsync();
                            return (StatusCodes.Status200OK, null);
                        }
                    }
                    return (null, null);
                }
                catch (Exception error)
                {
                    await Transaccion.RollbackAsync();
                    return (null, error);
                }
            }
            internal async Task<(int? StatusCode, Exception? Error)> DesactivarDescripcionProductoyRelaciones(ProductosDescripcion Descripcion)
            {
                using var Transaccion = await AponusDBContext.Database.BeginTransactionAsync();
                try
                {
                    //Busco Los PRODUCTOS relacioandos 
                    List<Producto> Productos = await AponusDBContext.Productos
                        .Where(x => x.IdDescripcion == Descripcion.IdDescripcion)
                        .Select(P => new Producto()
                        {
                            Cantidad = P.Cantidad,
                            IdDescripcion = P.IdDescripcion,
                            IdEstado = 0,
                            IdTipo = P.IdTipo,
                            DiametroNominal = P.DiametroNominal,
                            IdProducto = P.IdProducto,
                            PrecioFinal = P.PrecioFinal,
                            Tolerancia = P.Tolerancia,
                            PrecioLista = P.PrecioLista,
                            PorcentajeGanancia = P.PorcentajeGanancia,

                        }).ToListAsync();

                    // Cambio el estado de los PRODUCTOS a INACTIVO
                    AponusDBContext.ProductosDescripcions.Update(Descripcion);
                    if (Productos.Any()) AponusDBContext.Productos.UpdateRange(Productos);

                    await AponusDBContext.SaveChangesAsync();
                    await Transaccion.CommitAsync();

                    return (StatusCodes.Status200OK, null);
                }
                catch (Exception error)
                {
                    await Transaccion.RollbackAsync();
                    return (null, error);
                }
            }
        }
    }
}
