﻿using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Z.EntityFramework.Plus;

namespace Aponus_Web_API.Negocio
{
    public class BS_Stocks
    {
        private readonly AponusContext AponusDbContext;
        private readonly AD_Componentes _ComponentesProductos;
        private readonly AD_Stocks AdStocks;
        private readonly BS_Entidades BsEntidades;

        public BS_Stocks(AponusContext _aponusContext, AD_Stocks adStocks, AD_Componentes componentesProductos, BS_Entidades bsEntidades)
        {
            AponusDbContext = _aponusContext;
            AdStocks = adStocks;
            _ComponentesProductos = componentesProductos;
            BsEntidades = bsEntidades;
        }

        public StockInsumos OperacionesStockInsumos()
        {
            return new StockInsumos(AdStocks);
        }

        public StockProductos OperacionesStockProductos()
        {
            return new StockProductos(_ComponentesProductos, AponusDbContext, AdStocks);
        }
        internal JsonResult ListarProductos(string typeId, int idDescription)
        {
            List<DTOTiposProductos> ListadoProductos = AdStocks.ListarProductos();


            if (typeId.Equals("0") && idDescription != 0)
            {
                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.IdTipo == typeId && x.DescripcionProductos
                    .Any(d => d.IdDescripcion == idDescription))
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
                }));


                return new JsonResult(Lista);
            }
            else if (!typeId.Equals("0"))
            {
                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.IdTipo == typeId)
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
                }));

                return new JsonResult(Lista);
            }
            else if (idDescription != 0)
            {

                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.DescripcionProductos
                    .Any(x => x.IdDescripcion == idDescription))
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
                }));
                return new JsonResult(Lista);
            }
            else
            {
                ListadoProductos.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new UTL_Productos().ObtenerColumnas(dpp.Productos, null);
                }));

                return new JsonResult(ListadoProductos);
            }

        }
        internal IActionResult ObtenerDatosInsumos(int? IdDescripcion)
        {
            return AdStocks.ListarInsumosProducto(IdDescripcion);
        }
        internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock Movimiento)
        {
            bool Rollback = false;

            using (var transaccion = AponusDbContext.Database.BeginTransaction())
            {
                foreach (DTOSuministrosMovimientosStock suministro in Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                {
                    if (!AdStocks.ActualizarStockInsumo(AponusDbContext, new DTOStockUpdate()
                    {
                        Id = suministro.IdSuministro,
                        Origen = Movimiento.Origen,
                        Destino = Movimiento.Destino,
                        Cantidad = Convert.ToDecimal(suministro.Cantidad)
                    }))
                        Rollback = true;
                }

                int? IdMovimiento = AdStocks.GuardarDatosMovimiento(AponusDbContext, new Stock_Movimientos
                {
                    CreadoUsuario = Movimiento.UsuarioCreacion ?? "ERROR",
                    ModificadoUsuario = Movimiento.UsuarioModificacion,
                    FechaHoraCreado = UTL_Fechas.ObtenerFechaHora(),
                    IdProveedor = Movimiento.IdProveedorDestino ?? 0,
                    Tipo = Movimiento.Tipo,
                    Destino = !string.IsNullOrEmpty(Movimiento.Destino) ? Movimiento.Destino.ToUpper() : "",
                    Origen = !string.IsNullOrEmpty(Movimiento.Origen) ? Movimiento.Origen.ToUpper() : "",
                });

                if (IdMovimiento == null) Rollback = true;

                List<SuministrosMovimientosStock> Suministros = (Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                    .Select(x => new SuministrosMovimientosStock()
                    {
                        IdMovimiento = IdMovimiento ?? 0,
                        Cantidad = Convert.ToDecimal(x.Cantidad),
                        IdSuministro = x.IdSuministro,

                    })
                    .ToList();

                if (!AdStocks.GuardarSuministrosMovimiento(AponusDbContext, Suministros)) Rollback = true;

                //Obtener el Nombre del IdProveedorNavigation de Destino
                IActionResult Proveedores = BsEntidades.MapeoEntidadesDTO(Movimiento.IdProveedorDestino ?? 0, 0, 0);
                DTOEntidades? proveedor = new DTOEntidades();

                if (Proveedores is JsonResult jsonProveedores && jsonProveedores.Value != null && jsonProveedores.Value is IEnumerable<DTOEntidades> ProveedoresList)
                {
                    proveedor = ProveedoresList.FirstOrDefault(x => x.IdEntidad == Movimiento.IdProveedorDestino);

                }
                string? NombreCompletoProveedor = proveedor?.Apellido + "_" + proveedor?.Nombre;
                string? NombreClave = proveedor?.NombreClave;
                //Obtener el Nombre del Proveedora de Destino

                if (Movimiento.Archivos != null && Movimiento.Archivos.Count > 0)
                {
                    List<ArchivosMovimientosStock> DatosArchivosMovimiento = new UTL_Cloudinary().SubirArchivosMovimiento(Movimiento.Archivos,
                    string.IsNullOrEmpty(NombreClave) ? NombreCompletoProveedor : NombreClave);

                    if (DatosArchivosMovimiento.Count == 0) Rollback = true;

                    Movimiento.IdMovimiento = IdMovimiento;
                    DatosArchivosMovimiento.ForEach(x => x.IdMovimiento = IdMovimiento ?? 0);
                    if (!AdStocks.GuardarDatosArchivosMovimiento(AponusDbContext, DatosArchivosMovimiento)) Rollback = true;

                }

                if (Rollback)
                {
                    transaccion.Rollback();
                    return new ContentResult()
                    {
                        Content = $"Error interno, no se aplicaron los cambios",
                        ContentType = "Aplication/Json",
                        StatusCode = 500,
                    };
                }
                else
                {
                    AponusDbContext.Database.CommitTransaction();
                    AponusDbContext.SaveChanges();
                    AponusDbContext.Dispose();
                    return new StatusCodeResult(200);
                }

            }
        }
        public class StockProductos
        {
            private readonly AD_Componentes _componentesProductos;
            private readonly AponusContext AponusDbContext;
            private readonly AD_Stocks AdStocks;
            public StockProductos(AD_Componentes componentesProductos, AponusContext _aponusDbContext, AD_Stocks _adStocks)
            {
                _componentesProductos = componentesProductos;
                AponusDbContext = _aponusDbContext;
                AdStocks = _adStocks;
            }
            internal async Task<IActionResult> Actualizar(DTOStockProductos DTOStockProducto)
            {
                try
                {
                    Producto StockProductoDB = new Producto();
                    PropertyInfo[] PropsDTOStockProducto = DTOStockProducto.GetType().GetProperties(); //Valores que recibo                    
                    PropertyInfo[] PropsObjStockInsumosDB = StockProductoDB.GetType().GetProperties(); //Objeto para la Base de Datos

                    foreach (var PropDTO in PropsDTOStockProducto)
                        foreach (var PropObjDB in PropsObjStockInsumosDB)
                            if (PropObjDB.Name.ToLower().Contains(PropDTO.Name.ToLower()) && PropDTO.GetValue(DTOStockProducto) != null)
                                PropObjDB.SetValue(StockProductoDB, PropDTO.GetValue(DTOStockProducto));

                    bool Resultado = await AdStocks.StockProductos().Actualizar(StockProductoDB);

                    if (Resultado)
                        return new StatusCodeResult(200);
                    else
                        return new ContentResult()
                        {
                            Content = "No se aplicaron los cambios",
                            ContentType = "application/json",
                            StatusCode = 400
                        };
                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400
                    };

                }
            }
            internal async Task<IActionResult> Incrementar(DTOProducto Producto)
            {

                //Obtener Componentes Producto

                List<Productos_Componentes>? Componentes = !string.IsNullOrEmpty(Producto.IdProducto) ?
                    await _componentesProductos.ObtenerComponentes(Producto.IdProducto) : null;


                //IdDescripcion y Tipos de Almacenamiento/Fraccionamiento
                List<ComponentesDescripcion>? ComponentesDetalle = _componentesProductos.ListarNombresComponentes();

                //IdDescripcion y Tipos de Almacenamiento/Fraccionamiento

                //IdDescripcion por cada Componente
                List<(string id, int IdDesc, decimal? Longitud, decimal? Peso)> ListaDetallesComponentes = _componentesProductos.ListarIdDescripcionComponentesProducto(Componentes?.Select(x => x.IdComponente).ToArray() ?? Array.Empty<string>());
                //IdDescripcion por cada Componente


                List<Modelos.StockInsumos> StockComponentes = new List<Modelos.StockInsumos>();

                if (Componentes != null)
                {
                    foreach (var Componente in Componentes)
                    {
                        Componente.Cantidad = Componente.Cantidad == null ? null : (Producto.Cantidad ?? 00) * Componente.Cantidad;
                        Componente.Longitud = Componente.Longitud == null ? null : (Producto.Cantidad ?? 00) * Componente.Longitud;
                        Componente.Peso = Componente.Peso == null ? null : (Producto.Cantidad ?? 00) * Componente.Peso;

                        Modelos.StockInsumos StockDisponibleComponente = AdStocks.BuscarInsumo(Componente.IdComponente) ?? new Modelos.StockInsumos();

                        int IdDescripcionComponente = ListaDetallesComponentes.Where(x => x.Item1.Equals(Componente.IdComponente)).Select(x => x.Item2).First();
                        string TipoAlmacenamiento = ComponentesDetalle?.Where(x => x.IdDescripcion == IdDescripcionComponente).Select(x => x.IdAlmacenamiento).First() ?? "";
                        string? TipoFraccionamiento = ComponentesDetalle?.Where(x => x.IdDescripcion == IdDescripcionComponente).Select(x => x.IdFraccionamiento).First();

                        //Verifico si hay diferencia entre entre el tipo de Almacenamiento y el tipo de fraccionamienrto
                        if (TipoFraccionamiento != null && TipoAlmacenamiento != TipoFraccionamiento)
                        {
                            if (TipoFraccionamiento.Equals("UD") && TipoAlmacenamiento.Equals("KG"))
                            {
                                decimal PesoUnidadComponente = ListaDetallesComponentes.Where(x => x.Equals(Componente.IdComponente)).Select(x => x.Peso).First() ?? 0;
                                decimal PesoTotalUnProducto = PesoUnidadComponente * Componente.Cantidad ?? 1;
                                decimal PesoRequerido = PesoTotalUnProducto * Componente.Cantidad ?? 1;
                                decimal PesoDisponible = StockDisponibleComponente.Proceso ?? 0;
                                decimal PesoRestante = PesoDisponible - PesoRequerido;

                                StockComponentes.Add(new Modelos.StockInsumos()
                                {
                                    IdInsumo = Componente.IdComponente,
                                    Proceso = PesoRestante,
                                });

                            }
                            else if (TipoFraccionamiento.Equals("CM") && TipoAlmacenamiento.Equals("UD"))
                            {
                                decimal? LargoTotalInsumo = ListaDetallesComponentes.Where(x => x.id.Equals(Componente.IdComponente)).Select(x => x.Longitud).First();
                                decimal CantidadStock = StockDisponibleComponente.Proceso ?? 0;
                                decimal? LongitudTotalCmDisponible = (LargoTotalInsumo ?? 0) * CantidadStock;
                                decimal LongitudNecesaria = Componente.Longitud ?? 0 * Producto.Cantidad ?? 1;
                                decimal LongitudRestanteCm = LongitudTotalCmDisponible ?? 0 - LongitudNecesaria;

                                int CantidadRestante = (int)Math.Floor(LongitudRestanteCm / LargoTotalInsumo ?? 1);

                                StockComponentes.Add(new Modelos.StockInsumos()
                                {
                                    IdInsumo = Componente.IdComponente,
                                    Proceso = CantidadRestante,
                                });

                            }
                        }
                        else if (TipoFraccionamiento == null || TipoFraccionamiento.Equals(TipoAlmacenamiento))
                        {
                            TipoFraccionamiento = TipoAlmacenamiento;

                            if (TipoFraccionamiento.Equals("UD"))
                            {
                                decimal UnidadesUnProducto = Componente.Cantidad ?? 1;
                                decimal unidadesNecesarias = UnidadesUnProducto * Producto.Cantidad ?? 1;
                                decimal UnidadesStock = StockDisponibleComponente.Proceso ?? 0;
                                decimal UnidadesRestantess = UnidadesStock - unidadesNecesarias;

                                StockComponentes.Add(new Modelos.StockInsumos()
                                {
                                    IdInsumo = Componente.IdComponente,
                                    Proceso = UnidadesRestantess,
                                });


                            }
                            else if (TipoFraccionamiento.Equals("KG"))
                            {
                                decimal PesoUnProducto = Componente.Peso ?? 1;
                                decimal PesoNecesario = PesoUnProducto * Producto.Cantidad ?? 1;
                                decimal PesoStock = StockDisponibleComponente.Proceso ?? 0;
                                decimal PesoRestante = PesoStock - PesoNecesario;

                                StockComponentes.Add(new Modelos.StockInsumos()
                                {
                                    IdInsumo = Componente.IdComponente,
                                    Proceso = PesoRestante,
                                });
                            }
                            else if (TipoFraccionamiento.Equals("CM"))
                            {
                                decimal? LargoTotalInsumo = ListaDetallesComponentes.Where(x => x.id.Equals(Componente.IdComponente)).Select(x => x.Longitud).First();
                                decimal CantidadStock = StockDisponibleComponente.Proceso ?? 0;
                                decimal? LongitudTotalCmDisponible = (LargoTotalInsumo ?? 0) * CantidadStock;
                                decimal LongitudNecesaria = Componente.Longitud ?? 0 * Producto.Cantidad ?? 1;
                                decimal LongitudRestanteCm = LongitudTotalCmDisponible ?? 0 - LongitudNecesaria;

                                int CantidadRestante = (int)Math.Floor(LongitudRestanteCm / LargoTotalInsumo ?? 1);

                                StockComponentes.Add(new Modelos.StockInsumos()
                                {
                                    IdInsumo = Componente.IdComponente,
                                    Proceso = CantidadRestante,
                                });
                            }
                        }


                        bool NoRoolBack = false;

                        using (var transaccion = AponusDbContext.Database.BeginTransaction())
                        {
                            try
                            {
                                foreach (var item in StockComponentes)
                                {
                                    NoRoolBack = AdStocks.ActualizarStockInsumo(AponusDbContext, new DTOStockUpdate() { Id = item.IdInsumo, Cantidad = item.Proceso });

                                    if (!NoRoolBack)
                                    {
                                        transaccion.Rollback();
                                        return new ContentResult()
                                        {
                                            Content = "No se aplicaron los  cambios",
                                            ContentType = "application/json",
                                            StatusCode = 400,
                                        };
                                    }
                                }

                                transaccion.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaccion.Rollback();
                                return new ContentResult()
                                {
                                    Content = $"Error: {ex.InnerException?.Message ?? ex.Message}",
                                    ContentType = "application/json",
                                    StatusCode = 400,
                                };
                            }
                        }
                    }

                    return new StatusCodeResult(200);
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "Error interno, no se encontraron los componentes. No se aplicaron los cambios",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                }
            }
        }

        public class StockInsumos
        {
            private readonly AD_Stocks AdStocks;

            public StockInsumos(AD_Stocks adStocks)
            {
                AdStocks = adStocks;
            }
            internal async Task<IActionResult> Actualizar(DTOStock DtoStockInsumo)
            {
                try
                {
                    Modelos.StockInsumos ObjStockInsumosDB = new Modelos.StockInsumos();
                    PropertyInfo[] PropsDTOStockInsumo = DtoStockInsumo.GetType().GetProperties(); //Valores que recibo                    
                    PropertyInfo[] PropsObjStockInsumosDB = ObjStockInsumosDB.GetType().GetProperties(); //Objeto para la Base de Datos

                    foreach (var PropDTO in PropsDTOStockInsumo)
                        foreach (var PropObjDB in PropsObjStockInsumosDB)
                            if (PropObjDB.Name.ToLower().Contains(PropDTO.Name.ToLower()) && PropDTO.GetValue(DtoStockInsumo) != null)
                                PropObjDB.SetValue(ObjStockInsumosDB, PropDTO.GetValue(DtoStockInsumo));

                    bool Resultado = await AdStocks.StockInsumos().Actualizar(ObjStockInsumosDB);

                    if (Resultado)
                        return new StatusCodeResult(200);
                    else
                        return new ContentResult()
                        {
                            Content = "No se aplicaron los cambios",
                            ContentType = "application/json",
                            StatusCode = 400
                        };
                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400
                    };

                }

            }

        }
    }

}