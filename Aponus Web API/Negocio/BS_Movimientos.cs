using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Negocio
{
    public class BS_Movimientos
    {
        private readonly BS_Stocks BsStocks;
        private readonly AD_Stocks _stocks;
        private readonly AponusContext AponusDbContext;
        private readonly AD_Movimientos _movimientosStock;
        private readonly UTL_Suministros _suministros;
        private readonly AD_Suministros _obtenerInsumos;
        private readonly BS_Entidades BsEntidades;
        public BS_Movimientos(BS_Stocks bsStocks, AponusContext aponusDbContext, AD_Stocks stocks, AD_Movimientos movimientosStock, UTL_Suministros suministros, AD_Suministros obtenerInsumos, BS_Entidades bsEntidades)
        {
            BsStocks = bsStocks;
            _stocks = stocks;
            AponusDbContext = aponusDbContext;
            _movimientosStock = movimientosStock;
            _suministros = suministros;
            _obtenerInsumos = obtenerInsumos;
            BsEntidades = bsEntidades;
        }

        internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock DTOMovimiento)
        {
            try
            {
                List<StockInsumos> Insumos = new();

                foreach (DTOSuministrosMovimientosStock DTOSuministro in DTOMovimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                {
                    StockInsumos? Insumo = _stocks.BuscarInsumo(DTOSuministro.IdSuministro);
                    if (Insumo != null)
                        Insumos.Add(Insumo);
                }

                //Si encontré, en stock, todos los Suministros
                if (DTOMovimiento.Suministros?.Count == Insumos.Count)
                    return BsStocks.ProcesarDatosMovimiento(DTOMovimiento);
                else
                    return new ContentResult()
                    {
                        Content = "No se encontraron uno o mas Suministros\n No se realizaron modificaciones",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400,
                };
            }
        }

        internal IActionResult Actualizar(DTOMovimientosStock ActualizacionMovimiento)
        {
            try
            {
                _movimientosStock.Actualizar(ActualizacionMovimiento);

                return new StatusCodeResult(200);
            }
            catch (Exception)
            {

                return new ContentResult()
                {
                    Content = "Error interno, no se aplicaron los cambios",
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }

        }

        internal async Task<IActionResult> Listar(UTL_FiltrosMovimientos? Filtros)
        {
            List<DTOMovimientosStock> ListaMovimientos = await _movimientosStock.Listar(Filtros);

            List<string> SuministrosId = ListaMovimientos.SelectMany(x => x.Suministros != null ? x.Suministros.Select(s => s.IdSuministro) : Enumerable.Empty<string>()).ToList();
            List<(string IdSuministro, string NombreFormateado, string? Unidad)> SuministrosFormateados = _obtenerInsumos.ObtenerDetalles(SuministrosId);


            foreach (var movimiento in ListaMovimientos)
            {
                string FechaHora = movimiento.FechaHoraCreado.HasValue ? movimiento.FechaHoraCreado.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
                movimiento.FechaHoraCreado = Convert.ToDateTime(FechaHora);

                foreach (var suministro in movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                {
                    (string IdSuministro, string NombreFormateado, string? Unidad) SumFormat = SuministrosFormateados.FirstOrDefault(x => x.IdSuministro == suministro.IdSuministro);

                    suministro.NombreSuministro = SumFormat.NombreFormateado;
                    suministro.Cantidad = suministro.Cantidad + " " + SumFormat.Unidad;
                }
            }

            List<int?> MovimientosIds = ListaMovimientos.Select(m => m.IdMovimiento).Distinct().ToList();
            UTL_Cloudinary cloudinary = new UTL_Cloudinary();

            List<DTODatosArchivosMovimientosStock> InfoArchivosMovimientos = await _movimientosStock.InfoArchivos(MovimientosIds);

            foreach (DTODatosArchivosMovimientosStock item in InfoArchivosMovimientos ?? Enumerable.Empty<DTODatosArchivosMovimientosStock>())
            {
                var (archivo, error) = await cloudinary.DescargarArchivo(item?.Path ?? "");

                if (item != null)
                {
                    item.DatosArchivo = archivo;
                    item.MensajeError = error;
                }
            }


            foreach (DTOMovimientosStock Movimiento in ListaMovimientos)
                Movimiento.DatosArchivos = InfoArchivosMovimientos?.Where(x => x.IdMovimiento == Movimiento.IdMovimiento).ToList();

            return new JsonResult(ListaMovimientos);

        }

        internal IActionResult ActualizarSuministros(DTOMovimientosStock Movimiento)
        {
            bool RollBack = false;

            foreach (var Suministro in Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
            {
                Suministro.IdMovimiento = Movimiento.IdMovimiento;
            }
            List<SuministrosMovimientosStock>? suministros = _suministros.MapeoSuministrosDB(Movimiento.Suministros, Movimiento.Origen, Movimiento.Destino);


            suministros?.ForEach(x => x.IdMovimiento = Movimiento.IdMovimiento ?? -1);


            using (var transaccion = AponusDbContext.Database.BeginTransaction())
            {
                if (suministros != null && _stocks.GuardarSuministrosMovimiento(AponusDbContext, suministros)) RollBack = true;
                if (!_movimientosStock.RegistrarModificacion(AponusDbContext, Movimiento)) RollBack = true;

                if (RollBack)
                {
                    transaccion.Rollback();
                    return new ContentResult()
                    {
                        Content = "Error interno, no se aplicaron los cambios",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                }
                else
                {
                    AponusDbContext.Database.CommitTransaction();
                    AponusDbContext.SaveChanges();
                    return new StatusCodeResult(200);
                }
            }


        }

        internal IActionResult Eliminar(int IdMovimiento)
        {
            bool RollBack = false;

            using (var transaction = AponusDbContext.Database.BeginTransaction())
            {
                if (!_movimientosStock.Eliminar(AponusDbContext, IdMovimiento)) RollBack = true;

                if (RollBack)
                {
                    transaction.Rollback();
                    return new ContentResult()
                    {
                        Content = "Error interno, no se aplicaron los cambios",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                }
                else
                {
                    transaction.Commit();
                    AponusDbContext.SaveChanges();
                    return new StatusCodeResult(200);
                }
            }

        }

        public Archivos ArchivosMovimientos()
        {
            return new Archivos(AponusDbContext, _stocks, _movimientosStock, BsEntidades);
        }

        public Estados EstadosMovimientos()
        {
            return new Estados(AponusDbContext);
        }

        public class Archivos
        {
            private readonly AponusContext AponusDbContext;
            private readonly AD_Stocks stocks;
            private readonly AD_Movimientos _movimientosStock;
            private readonly BS_Entidades BsEntidades;
            public Archivos(AponusContext aponusDbContext, AD_Stocks _stocks, AD_Movimientos movimientosStock, BS_Entidades bsEntidades)
            {
                AponusDbContext = aponusDbContext;
                stocks = _stocks;
                _movimientosStock = movimientosStock;
                BsEntidades = bsEntidades;
            }

            internal async Task<IActionResult> Agregar(DTOMovimientosStock ArchivosMovimiento)
            {


                //Obtener los datos completos del movimiento
                DTOMovimientosStock? DatosMovimiento = await _movimientosStock.ObtenerDatosMovimiento(ArchivosMovimiento.IdMovimiento ?? -1);
                List<DTOEntidades>? Proveedores = new List<DTOEntidades>();

                if (DatosMovimiento != null)
                {
                    IActionResult ProveedoresActionResult = BsEntidades.MapeoEntidadesDTO(ArchivosMovimiento.IdProveedorDestino ?? 0, 0, 0);

                    if (ProveedoresActionResult is JsonResult jsonProveedores && jsonProveedores.Value != null && jsonProveedores.Value is IEnumerable<DTOEntidades> ProveedoresList)
                    {
                        DTOEntidades? proveedor = ProveedoresList
                            .Where(x => x.IdEntidad == ArchivosMovimiento.IdProveedorDestino)
                            .Select(x => new DTOEntidades()
                            {
                                Apellido = x.Apellido,
                                Nombre = x.Nombre,
                                NombreClave = x.NombreClave,
                            })
                            .FirstOrDefault();

                        //Copiar los archivos 
                        if (ArchivosMovimiento.Archivos != null && proveedor != null)
                        {
                            List<ArchivosMovimientosStock> DatosArchivos = new UTL_Cloudinary().SubirArchivosMovimiento(ArchivosMovimiento.Archivos,
                                !string.IsNullOrEmpty(proveedor?.NombreClave) ? proveedor.NombreClave : proveedor?.Apellido + "_" + proveedor?.Nombre);

                            DatosArchivos.ForEach(x => x.IdMovimiento = ArchivosMovimiento.IdMovimiento ?? 0);

                            //ProcesarDatos info Cloudiary
                            using (var transacccion = AponusDbContext.Database.BeginTransaction())
                            {
                                bool RollBack = false;

                                if (stocks.GuardarDatosArchivosMovimiento(AponusDbContext, DatosArchivos)) RollBack = true;
                                if (_movimientosStock.RegistrarModificacion(AponusDbContext, ArchivosMovimiento)) RollBack = true;

                                if (RollBack)
                                {
                                    transacccion.Rollback();
                                    return new ContentResult()
                                    {
                                        Content = "Error Interno, No se aplicaron los cambios",
                                        ContentType = "application/json",
                                        StatusCode = 400,
                                    };

                                }
                                else
                                {
                                    AponusDbContext.SaveChanges();
                                    AponusDbContext.Database.CommitTransaction();
                                    return new StatusCodeResult(200);
                                }
                            }
                        }
                        else
                        {
                            return new ContentResult()
                            {
                                Content = "Faltan Datos",
                                ContentType = "application/json",
                                StatusCode = 400,
                            };
                        }
                    }
                    else
                    {
                        return new ContentResult()
                        {
                            Content = "No se encontró el IdProveedorNavigation",
                            ContentType = "application/json",
                            StatusCode = 400,
                        };
                    }
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "No se encontró el movimiento",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                }

            }

            internal IActionResult Eliminar(DTOMovimientosStock Movimiento)
            {

                var ArchivosMovimientos = _movimientosStock.Archivos();

                bool Rollback = false;

                if (Movimiento.DatosArchivos != null)
                {
                    using (var transaccion = AponusDbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            if (!ArchivosMovimientos.Eliminar(AponusDbContext, Movimiento?.IdMovimiento ?? -1, Movimiento?.DatosArchivos?.Select(x => x.NombreArchivo ?? "").First() ?? "")) Rollback = true;
                            if (!_movimientosStock.RegistrarModificacion(AponusDbContext, Movimiento ?? new DTOMovimientosStock())) Rollback = true;


                            if (Rollback)
                            {
                                transaccion.Rollback();
                                return new ContentResult()
                                {
                                    Content = "Error interno, no se aplicaron los cambios",
                                    ContentType = "application/json",
                                    StatusCode = 500,
                                };

                            }
                            else
                            {
                                AponusDbContext.SaveChanges();
                                AponusDbContext.Database.CommitTransaction();
                                return new StatusCodeResult(200);
                            }

                        }
                        catch (Exception)
                        {

                            return new ContentResult()
                            {
                                Content = "Error interno, no se aplicaron los cambios",
                                ContentType = "application/json",
                                StatusCode = 500,
                            };
                        }
                    }
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "Faltan los archivos a ValidarCategoria",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                }
            }
        }

        public class Estados
        {
            private readonly AponusContext AponusDbContext;
            public Estados(AponusContext aponusDbContext)
            {
                AponusDbContext = aponusDbContext;
            }

            public IActionResult Listar()
            {
                var Listado = AD_Movimientos.Estados.Listar(AponusDbContext);
                return new JsonResult(Listado);
            }

            internal async Task<IActionResult> Guardar(DTOEstadosMovimientosStock estado)
            {
                estado.Descripcion = Regex.Replace(estado.Descripcion, @"\s+", " ").Trim().ToUpper();
                string insert = @"INSERT INTO ""ESTADOS_MOVIMIENTOS_STOCK"" (""DESCRIPCION"") VALUES (@DESCRIPCION)";

                try
                {
                    var Existe = AponusDbContext.EstadoMovimientosStock.Find(estado.idEstadoMovimiento);

                    if (Existe != null)
                    {
                        Existe.IdEstado = estado.IdEstado ?? Existe.IdEstado;
                        Existe.Descripcion = estado.Descripcion ?? Existe.Descripcion;
                        Existe.IdEstadoMovimiento = estado.idEstadoMovimiento ?? Existe.IdEstadoMovimiento;
                        AponusDbContext.EstadoMovimientosStock.Update(Existe);

                        await AponusDbContext.SaveChangesAsync();

                        return new StatusCodeResult(200);

                    }
                    else
                    {
                        await AponusDbContext.Database.ExecuteSqlRawAsync(insert, new NpgsqlParameter("@DESCRIPCION", estado.Descripcion)
                        {
                            NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                        });

                        return new StatusCodeResult(200);
                    }
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }
    }
}
