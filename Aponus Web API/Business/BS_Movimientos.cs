using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Aponus_Web_API.Support.Movimientos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Aponus_Web_API.Business
{
    public class BS_Movimientos
    {
        internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock Movimiento)
        {

           
            try
            {
                Stocks Stocks = new Stocks();
                List<StockInsumos> Suministros = new();                

                foreach (DTOSuministrosMovimientosStock Suministro in Movimiento.Suministros)
                {
                    Suministros.Add(Stocks.BuscarInsumo(Suministro.IdSuministro));
                    
                }

                //Si encontré, en stock, todos los suministros
                if (Suministros.Count > 0 && Movimiento.Suministros.Count==Suministros.Count)
                {

                    Movimiento.Suministros = Suministros
                                                    .Join(Movimiento.Suministros,
                                                    SuministrosStockInsumos => SuministrosStockInsumos.IdInsumo,
                                                    SuministrosMovimientosStock => SuministrosMovimientosStock.IdSuministro,
                                                    (suministrosStockInsumos, suministrosMovimientosStock) => new
                                                    {
                                                        suministrosStockInsumos,
                                                        suministrosMovimientosStock
                                                    })
                                                    .Select(x => new DTOSuministrosMovimientosStock()
                                                    {
                                                        IdSuministro = x.suministrosMovimientosStock.IdSuministro,
                                                        Cantidad = x.suministrosMovimientosStock.Cantidad,                                                        

                                                        ValorAnteriorOrigen = (x.suministrosStockInsumos
                                                            .GetType()?
                                                            .GetProperties()?
                                                            .FirstOrDefault(y => y.Name.ToUpper().Contains(Movimiento?.Origen?.ToUpper() ?? string.Empty))?
                                                            .GetValue(x.suministrosStockInsumos) ?? 0)
                                                            .ToString(),                                                        
                                                            

                                                        ValorAnteriorDestino = (x.suministrosStockInsumos
                                                            .GetType()?
                                                            .GetProperties()?
                                                            .FirstOrDefault(y => y.Name.ToUpper().Contains(Movimiento?.Destino?.ToUpper() ?? string.Empty))?
                                                            .GetValue(x.suministrosStockInsumos)?? 0)
                                                            .ToString()

                                                    })
                                                    .ToList();


                    return new ModificacionesStocks().newActualizarStockInsumo(Movimiento);
                }                   
                
                else
                {
                    if (Movimiento.Origen == null || Movimiento.Destino== null)
                        return new ContentResult()
                        {
                            Content="Los campos 'Origen' y 'Destino' no pueden ser nulos",
                            ContentType= "application/json",
                            StatusCode=400
                        };

                    var Resultado = new ObjectResult("No se encontraron uno o mas suministros\n No se realizaron modificaciones")
                    {
                        StatusCode = 400,
                    };
                    return Resultado;
                }
            }
            catch (Exception)
            {
                return new JsonResult(new StatusCodeResult(400));

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

       

        internal IActionResult Listar(FiltrosMovimientos? Filtros)
        {
            if (Filtros!=null)
                return new MovimientosStock().Listar(Filtros);
            else
                return new MovimientosStock().Listar();
        
        }

        internal IActionResult ActualizarSuministros(DTOMovimientosStock Movimiento)
        {
            //SuministrosMovimientosStock Suministros = new SuministrosMovimientosStock();
            MovimientosStock Movimientos = new();
            Stocks stocks = new Stocks();
            bool RollBack = false;

            foreach (var Suministro in Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
            {
                Suministro.IdMovimiento = Movimiento.IdMovimiento;
            }
            List<SuministrosMovimientosStock>? suministros = Suministros.MapeoSuministrosDB(Movimiento.Suministros, Movimiento.Origen, Movimiento.Destino);


            foreach (SuministrosMovimientosStock suministro in suministros ?? Enumerable.Empty<SuministrosMovimientosStock>())
            {
                if (suministro.ValorNuevoOrigen< 0)
                    return new ContentResult()
                    {
                        Content = $"La cantidad en del Suministro Id:{suministro.IdSuministro} Disponible en " +
                                    $"{Movimiento.Origen} es inferior a la disponible en {Movimiento.Destino}",
                        ContentType = "Aplication/Json",
                        StatusCode = 400,
                    };

                suministro.IdMovimiento = Movimiento.IdMovimiento ?? -1;
            }

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
            internal IActionResult Agregar(DTOMovimientosStock ArchivosMovimiento)
            {
                Stocks stocks = new Stocks();
                

                using (AponusContext AponusDBContext = new AponusContext())
                {
                    //Obtener los datos completos del movimiento
                    DTOMovimientosStock? DatosMovimiento = new MovimientosStock().ObtenerDatosMovimiento(ArchivosMovimiento.IdMovimiento ?? -1);
                    List<DTOEntidades>? Proveedores = new List<DTOEntidades>();

                    if (DatosMovimiento != null)
                    {
                        //Buscar el Movimiento y la ruta en donde se guardaron los archivos anteriores
                        string? RutaCompleta = DatosMovimiento.DatosArchivos.Select(x => x.Path).First();

                        //Si existe el movimiento pero no hay rutas de archivos, es decir, no se guardaron archivos antes entonces genero la ruta
                        if (string.IsNullOrEmpty(RutaCompleta))
                        {
                            IActionResult ProveedoresActionResult = BS_Entidades.Listar(ArchivosMovimiento.IdProveedorDestino ?? 0 , 0, 0);

                            DTOEntidades proveedor = new DTOEntidades();

                            if (ProveedoresActionResult is JsonResult jsonProveedores && jsonProveedores.Value != null && jsonProveedores.Value is IEnumerable<DTOEntidades> ProveedoresList)
                            {
                                proveedor = ProveedoresList.FirstOrDefault(x => x.IdEntidad == ArchivosMovimiento.IdProveedorDestino);
                                RutaCompleta = stocks.CrearDirectorioMovimientos(!string.IsNullOrEmpty(proveedor.NombreClave) ? proveedor.NombreClave : proveedor.Apellido + " " + proveedor.Nombre);

                            }
                          
                        }

                        //Copiar los archivos 
                        List<ArchivosMovimientosStock> DatosArchivos = stocks.CopiarArchivosMovimientos(ArchivosMovimiento.Archivos, Path.GetDirectoryName(RutaCompleta));
                        DatosArchivos.ForEach(x => x.IdMovimiento = (int)ArchivosMovimiento.IdMovimiento);

                        //Guardar los datos los archivos previamente copiados
                        using (var transacccion = AponusDBContext.Database.BeginTransaction())
                        {
                            bool RollBack = false;

                            if (!stocks.GuardarDatosArchivosMovimiento(AponusDBContext, DatosArchivos)) RollBack = true;
                            if (!new MovimientosStock().RegistrarModificacion(AponusDBContext, ArchivosMovimiento)) RollBack = true;

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
                                AponusDBContext.Database.CommitTransaction();
                                AponusDBContext.SaveChanges();
                                return new StatusCodeResult(200);
                            }

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
                string insert = "INSERT INTO ESTADOS_MOVIMIENTOS_STOCK (DESCRIPCION) VALUES (@DESCRIPCION)";
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
                                new SqlParameter("@DESCRIPCION", estado.Descripcion.Trim().ToUpper()));


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
