using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Aponus_Web_API.Support.Movimientos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Business
{
    public class BS_Movimientos
    {
        internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock DTOMovimiento)
        {
            try
            {
                Stocks Stocks = new Stocks();
                List<StockInsumos> Insumos = new();                

                foreach (DTOSuministrosMovimientosStock DTOSuministro in DTOMovimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                {
                    StockInsumos? Insumo = Stocks.BuscarInsumo(DTOSuministro.IdSuministro);
                    if (Insumo != null)
                        Insumos.Add(Insumo);
                }

                //Si encontré, en stock, todos los Suministros
                if (DTOMovimiento.Suministros?.Count == Insumos.Count)
                    return new BS_Stocks().ProcesarDatosMovimiento(DTOMovimiento);
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
                    Content =  ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400,
                };
            }
        }

        internal IActionResult Actualizar(DTOMovimientosStock ActualizacionMovimiento)
        {

            try
            {
                new MovimientosStock().Actualizar(ActualizacionMovimiento);
                
                return new StatusCodeResult(200);
            }
            catch (Exception)
            {

                return new ContentResult()
                {
                    Content="Error interno, no se aplicaron los cambios",
                    ContentType= "application/json",
                    StatusCode=400
                };
            }

        }

       

        internal async Task<IActionResult> Listar(FiltrosMovimientos? Filtros)
        {
            List<DTOMovimientosStock> ListaMovimientos = await new MovimientosStock().Listar(Filtros);

            List<string> SuministrosId = ListaMovimientos.SelectMany(x => x.Suministros != null ? x.Suministros.Select(s => s.IdSuministro) : Enumerable.Empty<string>()).ToList();
            List<(string IdSuministro, string NombreFormateado, string? Unidad)> SuministrosFormateados = new ObtenerInsumos().ObtenerDetalleSuministro(SuministrosId);


            foreach (var movimiento in ListaMovimientos)
            {
                string FechaHora = movimiento.FechaHoraCreado.HasValue ? movimiento.FechaHoraCreado.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
                movimiento.FechaHoraCreado = Convert.ToDateTime(FechaHora);

                foreach (var suministro in movimiento.Suministros)
                {
                    (string IdSuministro, string NombreFormateado, string? Unidad) SumFormat = SuministrosFormateados.FirstOrDefault(x => x.IdSuministro == suministro.IdSuministro);

                    suministro.NombreSuministro = SumFormat.NombreFormateado;
                    suministro.Cantidad = suministro.Cantidad + " " + SumFormat.Unidad;
                }
            }

            List<int?> MovimientosIds = ListaMovimientos.Select(m => m.IdMovimiento).Distinct().ToList();
            CloudinaryService cloudinary = new CloudinaryService();

            List<DTODatosArchivosMovimientosStock> InfoArchivosMovimientos = await new MovimientosStock().InfoArchivos(MovimientosIds);

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
                Movimiento.DatosArchivos = InfoArchivosMovimientos.Where(x => x.IdMovimiento == Movimiento.IdMovimiento).ToList();

            return new JsonResult(ListaMovimientos);

        }

        internal IActionResult ActualizarSuministros(DTOMovimientosStock Movimiento)
        {
            //SuministrosMovimientosStock Insumos = new SuministrosMovimientosStock();
            MovimientosStock Movimientos = new();
            Stocks stocks = new Stocks();
            bool RollBack = false;

            foreach (var Suministro in Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
            {
                Suministro.IdMovimiento = Movimiento.IdMovimiento;
            }
            List<SuministrosMovimientosStock>? suministros = Suministros.MapeoSuministrosDB(Movimiento.Suministros, Movimiento.Origen, Movimiento.Destino);


            suministros?.ForEach(x => x.IdMovimiento = Movimiento.IdMovimiento ?? -1);
            
            
            using (AponusContext AponusDbContext = new AponusContext())
            {


                using (var transaccion = AponusDbContext.Database.BeginTransaction())
                {
                    if (!stocks.GuardarSuministrosMovimiento(AponusDbContext, suministros )) RollBack = true;
                    if (!Movimientos.RegistrarModificacion(AponusDbContext, Movimiento)) RollBack = true;

                    if (RollBack)
                    {
                        transaccion.Rollback();
                        return new ContentResult()
                        {
                            Content="Error interno, no se aplicaron los cambios",
                            ContentType ="application/json",
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


        }

        internal IActionResult Eliminar(int IdMovimiento)
        {
            bool RollBack = false;
            using (AponusContext AponusDBContext = new AponusContext())
            {
                using (var transaction = AponusDBContext.Database.BeginTransaction())
                {
                    if (!MovimientosStock.Eliminar(AponusDBContext, IdMovimiento)) RollBack = true;

                    if (RollBack)
                    {
                        transaction.Rollback();
                        return new ContentResult()
                        {
                            Content="Error interno, no se aplicaron los cambios",
                            ContentType="application/json",
                            StatusCode=400
                        };
                    }else
                    {
                        transaction.Commit();
                        AponusDBContext.SaveChanges();
                        return new StatusCodeResult(200);       
                    }
                }
                    

               
            }
        }

        public class Archivos
        {
            internal async Task<IActionResult> Agregar(DTOMovimientosStock ArchivosMovimiento)
            {
                MovimientosStock Operaciones_Movimientos_Stock = new MovimientosStock();                

                using (AponusContext AponusDBContext = new AponusContext())
                {
                    //Obtener los datos completos del movimiento
                    DTOMovimientosStock? DatosMovimiento = await Operaciones_Movimientos_Stock.ObtenerDatosMovimiento(ArchivosMovimiento.IdMovimiento ?? -1);
                    List<DTOEntidades>? Proveedores = new List<DTOEntidades>();

                    if (DatosMovimiento != null)
                    {
                        IActionResult ProveedoresActionResult = BS_Entidades.Listar(ArchivosMovimiento.IdProveedorDestino ?? 0 , 0, 0);

                        if (ProveedoresActionResult is JsonResult jsonProveedores && jsonProveedores.Value != null && jsonProveedores.Value is IEnumerable<DTOEntidades> ProveedoresList)
                        {
                            DTOEntidades? proveedor = ProveedoresList
                                .Where(x => x.IdEntidad == ArchivosMovimiento.IdProveedorDestino)
                                .Select(x=> new DTOEntidades()
                                {
                                    Apellido = x.Apellido,
                                    Nombre = x.Nombre,
                                    NombreClave = x.NombreClave,
                                })
                                .FirstOrDefault();

                            //Copiar los archivos 
                            if (ArchivosMovimiento.Archivos != null && proveedor != null)
                            {
                                List<ArchivosMovimientosStock> DatosArchivos = new CloudinaryService().SubirArchivosMovimiento(ArchivosMovimiento.Archivos,
                                    !string.IsNullOrEmpty(proveedor?.NombreClave) ? proveedor.NombreClave : proveedor?.Apellido + "_" + proveedor?.Nombre);

                                DatosArchivos.ForEach(x => x.IdMovimiento = ArchivosMovimiento.IdMovimiento ?? 0) ;

                                //ProcesarDatos info Cloudiary
                                using (var transacccion = AponusDBContext.Database.BeginTransaction())
                                {
                                    bool RollBack = false;

                                    if (new Stocks().GuardarDatosArchivosMovimiento(AponusDBContext, DatosArchivos)) RollBack = true;
                                    if (Operaciones_Movimientos_Stock.RegistrarModificacion(AponusDBContext, ArchivosMovimiento)) RollBack = true;

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
                                        AponusDBContext.SaveChanges();
                                        AponusDBContext.Database.CommitTransaction();
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
                                Content = "No se encontró el IdProveedor",
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
            }

            internal IActionResult Eliminar(DTOMovimientosStock Movimiento)
            {

                using (AponusContext AponusDbContext = new AponusContext())
                {
                    MovimientosStock.Archivos ArchivosMovimientos = new MovimientosStock.Archivos();
                    MovimientosStock Movimientos = new MovimientosStock();

                    bool Rollback = false;

                    if (Movimiento.DatosArchivos != null)
                    {
                        using (var transaccion = AponusDbContext.Database.BeginTransaction())
                        {
                            try
                            {
                                if (!ArchivosMovimientos.Eliminar(AponusDbContext, (int)Movimiento.IdMovimiento, Movimiento.DatosArchivos.Select(x=>x.NombreArchivo).First())) Rollback = true;
                                if (!Movimientos.RegistrarModificacion(AponusDbContext, Movimiento)) Rollback = true;

                                
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
                            Content = "Faltan los archivos a Eliminar",
                            ContentType = "application/json",
                            StatusCode = 400,

                        };
                    }

                }
                
            }
        }

        public class Estados
        {
            public static IActionResult Listar()
            {
                
                using (AponusContext AponusDbContext = new AponusContext())
                {
                    var Listado = MovimientosStock.Estados.Listar(AponusDbContext);
                    return new JsonResult(Listado);
                }

               
            }

            internal static async Task<IActionResult> Guardar(DTOEstadosMovimientosStock estado)
            {
                estado.Descripcion = Regex.Replace(estado.Descripcion, @"\s+", " ").Trim().ToUpper();
                string insert = @"INSERT INTO ""ESTADOS_MOVIMIENTOS_STOCK"" (""DESCRIPCION"") VALUES (@DESCRIPCION)";

                try
                {
                    using (AponusContext AponusDbContext = new AponusContext())
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

                            await AponusDbContext.Database.ExecuteSqlRawAsync(insert,
                                            new NpgsqlParameter("@DESCRIPCION", estado.Descripcion)
                                            {
                                                NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar 
                                            });

                            return new StatusCodeResult(200);
                        }
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
