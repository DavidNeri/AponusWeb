using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Movimientos
    {
        private readonly AponusContext AponusDBContext;
        public AD_Movimientos(AponusContext _AponusDbContext)
        {
            AponusDBContext = _AponusDbContext;
        }

        public ArchivosMovimientos Archivos()
        {
            return new ArchivosMovimientos(AponusDBContext);
        }
        public Estados EstadosMovimientos()
        {
            return new Estados(AponusDBContext);
        }

        public class Estados
        {
            private readonly AponusContext AponusDbContext;
            public Estados(AponusContext aponusDbContext)
            {
                AponusDbContext = aponusDbContext;
            }

            internal static List<EstadosMovimientosStock> Listar(AponusContext AponusDbContext)
            {
                return AponusDbContext.EstadoMovimientosStock.Where(x => x.IdEstado != 0 && !x.Descripcion.ToUpper().Contains("ELIMINADO")).ToList();

            }
        }

        public class ArchivosMovimientos
        {
            private readonly AponusContext AponusDBContext;
            public ArchivosMovimientos(AponusContext _AponusDBContext)
            {
                AponusDBContext = _AponusDBContext;
            }

            public bool Eliminar(AponusContext AponusDB, int IdMov, string Archivo)
            {
                try
                {
                    var ArchivoExistente = AponusDB.ArchivosStock.Where(x => x.IdMovimiento == IdMov && x.HashArchivo.Contains(Archivo)).FirstOrDefault();

                    if (ArchivoExistente != null)
                    {
                        ArchivoExistente.IdEstado = 0;
                        AponusDB.ArchivosStock.Update(ArchivoExistente);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
        }
        internal async Task<DTOMovimientosStock?> ObtenerDatosMovimiento(int idMovimiento)
        {

            UTL_Cloudinary cloudinary = new UTL_Cloudinary();

            DTOMovimientosStock? Movimiento = AponusDBContext.Stock_Movimientos
                .Where(x => x.IdMovimiento == idMovimiento)
                .Select(x => new DTOMovimientosStock()
                {
                    IdMovimiento = x.IdMovimiento,
                    UsuarioCreacion = x.CreadoUsuario,
                    FechaHoraCreado = x.FechaHoraCreado,
                    FechaHoraUltimaModificacion = x.FechaHoraUltimaModificacion,
                    IdProveedorDestino = x.IdProveedor,
                    UsuarioModificacion = x.ModificadoUsuario,


                    DatosArchivos = AponusDBContext.ArchivosStock
                    .Where(x => x.IdMovimiento == x.IdMovimiento && x.IdEstado == 1)
                    .Select(x => new DTODatosArchivosMovimientosStock()
                    {
                        IdMovimiento = x.IdMovimiento,
                        NombreArchivo = x.HashArchivo,
                        MimeType = x.MimeType,
                        Path = x.PathArchivo,
                        Extension = Path.GetExtension(x.PathArchivo),
                    }).ToList()
                })
                .FirstOrDefault();


            foreach (DTODatosArchivosMovimientosStock Archivo in Movimiento?.DatosArchivos ?? Enumerable.Empty<DTODatosArchivosMovimientosStock>())
            {
                if (Archivo != null)
                {
                    var (Publicurl, error) = await cloudinary.DescargarArchivo(Archivo?.Path ?? "");
                    Archivo.NombreArchivo = Publicurl;
                    Archivo.MensajeError = error;
                }
            }
            return Movimiento;
        }
        public async Task<List<DTOMovimientosStock>> Listar(UTL_FiltrosMovimientos? Filtros = null)
        {

            if (Filtros != null)
            {
                IQueryable<DTOMovimientosStock> IQMovimientos = AponusDBContext.Stock_Movimientos
                .Where(movimiento =>
                    (!Filtros.Desde.HasValue || movimiento.FechaHoraCreado >= Filtros.Desde.Value) &&
                    (!Filtros.Hasta.HasValue || movimiento.FechaHoraCreado <= Filtros.Hasta.Value) &&
                    (string.IsNullOrEmpty(Filtros.Etapa) || (movimiento.Destino != null && movimiento.Destino.Contains(Filtros.Etapa))) &&
                    (!Filtros.IdProveedor.HasValue || movimiento.IdProveedor == Filtros.IdProveedor) &&
                    (!Filtros.IdMovimiento.HasValue || movimiento.IdMovimiento == Filtros.IdMovimiento.Value))
                    
                .Join(
                    AponusDBContext.Entidades,
                    movimientos => movimientos.IdProveedor,
                    proveedorDestino => proveedorDestino.IdEntidad,
                    (movimiento, proveedor) => new { Movimiento = movimiento, Proveedor = proveedor }
                )
                .Join(
                    AponusDBContext.SuministrosMovimientoStock,
                    Movimiento_Provedor => Movimiento_Provedor.Movimiento.IdMovimiento,
                    SuministrosMovimientos => SuministrosMovimientos.IdMovimiento,
                    (Movimientos_Proveedor, SuministrosMovimientos) => new { movimiento_proveedor = Movimientos_Proveedor, suministrosMovimientos = SuministrosMovimientos }

                )
                .Join(
                    AponusDBContext.ComponentesDetalles,
                    Movimientos_Proveedores_Suministros => Movimientos_Proveedores_Suministros.suministrosMovimientos.IdSuministro,
                    SuministrosDetalle => SuministrosDetalle.IdInsumo,
                    (movimientos_Proveedores_Suministros, suministrosDetalle) => new { Movimientos_Proveedores_Suministros = movimientos_Proveedores_Suministros, SuministrosDetalle = suministrosDetalle })

                .Join(
                    AponusDBContext.EstadoMovimientosStock,
                    Mov_Prov_Sum_Det => Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento,
                    Estados => Estados.IdEstadoMovimiento,
                    (Mov_Prov_Sum_Det, Estados) => new { Mov_Prov_Sum_Det, Estados })

                .Where(x => x.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento != 0)
                .Select(result => new DTOMovimientosStock()
                {
                    IdMovimiento = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento,
                    FechaHoraCreado = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.FechaHoraCreado,
                    UsuarioCreacion = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.CreadoUsuario,
                    Origen = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Origen,
                    Destino = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Destino,
                    Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.Estados.Descripcion.ToLower()),

                    Suministros = AponusDBContext.SuministrosMovimientoStock
                    .Where(s => s.IdMovimiento == result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento && s.IdEstado != 0)
                    .Select(s => new DTOSuministrosMovimientosStock()
                    {
                        IdMovimiento = s.IdMovimiento,
                        IdSuministro = s.IdSuministro,
                        Cantidad = !string.IsNullOrEmpty(s.Cantidad.ToString()) ?
                            s.Cantidad.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento) :
                            0.00.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento),
                    })
                    .ToList(),

                    Proveedor = new DTOEntidades()
                    {
                        IdEntidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.IdEntidad,
                        Nombre = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Nombre,
                        Apellido = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Apellido,
                        NombreClave = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.NombreClave,
                    }
                });
                return await IQMovimientos.ToListAsync();
            }
            else
            {
                IQueryable<DTOMovimientosStock> IQMovimientos = AponusDBContext.Stock_Movimientos
                .Join(
                    AponusDBContext.Entidades,
                    movimientos => movimientos.IdProveedor,
                    proveedorDestino => proveedorDestino.IdEntidad,
                    (movimiento, proveedor) => new { Movimiento = movimiento, Proveedor = proveedor }
                )
                .Join(
                    AponusDBContext.SuministrosMovimientoStock,
                    Movimiento_Provedor => Movimiento_Provedor.Movimiento.IdMovimiento,
                    SuministrosMovimientos => SuministrosMovimientos.IdMovimiento,
                    (Movimientos_Proveedor, SuministrosMovimientos) => new { movimiento_proveedor = Movimientos_Proveedor, suministrosMovimientos = SuministrosMovimientos }

                )
                .Join(
                    AponusDBContext.ComponentesDetalles,
                    Movimientos_Proveedores_Suministros => Movimientos_Proveedores_Suministros.suministrosMovimientos.IdSuministro,
                    SuministrosDetalle => SuministrosDetalle.IdInsumo,
                    (movimientos_Proveedores_Suministros, suministrosDetalle) => new { Movimientos_Proveedores_Suministros = movimientos_Proveedores_Suministros, SuministrosDetalle = suministrosDetalle })

                .Join(
                    AponusDBContext.EstadoMovimientosStock,
                    Mov_Prov_Sum_Det => Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento,
                    Estados => Estados.IdEstadoMovimiento,
                    (Mov_Prov_Sum_Det, Estados) => new { Mov_Prov_Sum_Det, Estados })

                .Where(x => x.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdEstadoMovimiento != 0)
                .Select(result => new DTOMovimientosStock()
                {
                    IdMovimiento = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento,
                    FechaHoraCreado = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.FechaHoraCreado,
                    UsuarioCreacion = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.CreadoUsuario,
                    Origen = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Origen,
                    Destino = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.Destino,
                    Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.Estados.Descripcion.ToLower()),

                    Suministros = AponusDBContext.SuministrosMovimientoStock
                    .Where(s => s.IdMovimiento == result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Movimiento.IdMovimiento && s.IdEstado != 0)
                    .Select(s => new DTOSuministrosMovimientosStock()
                    {
                        IdMovimiento = s.IdMovimiento,
                        IdSuministro = s.IdSuministro,
                        Cantidad = !string.IsNullOrEmpty(s.Cantidad.ToString()) ?
                            s.Cantidad.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento) :
                            0.00.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento),
                    })
                    .ToList(),

                    Proveedor = new DTOEntidades()
                    {
                        IdEntidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.IdEntidad,
                        Nombre = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Nombre,
                        Apellido = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.Apellido,
                        NombreClave = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimiento_proveedor.Proveedor.NombreClave,
                    }
                });

                return await IQMovimientos.ToListAsync();
            }
        }
        internal async Task<List<DTODatosArchivosMovimientosStock>> InfoArchivos(List<int?> ListaMovimientos)
        {
            try
            {
                List<DTODatosArchivosMovimientosStock> InfoArchivosMovimientos = await AponusDBContext.ArchivosStock
                           .Where(Id => ListaMovimientos.Contains(Id.IdMovimiento))
                           .Select(Reg => new DTODatosArchivosMovimientosStock()
                           {
                               IdMovimiento = Reg.IdMovimiento,
                               NombreArchivo = Reg.HashArchivo,
                               Path = Reg.PathArchivo,
                               Extension = Path.GetExtension(Reg.PathArchivo),
                               MimeType = ObtenerMimeType(Reg.PathArchivo),
                           }).ToListAsync();

                return InfoArchivosMovimientos;
            }
            catch (Exception)
            {

                return new List<DTODatosArchivosMovimientosStock>();
            }

        }
        private async static Task<byte[]> DescargarArchivoMovimiento_Local(string url)
        {
            HttpClient webClient = new HttpClient();
            byte[] archivoBites = await webClient.GetByteArrayAsync(url);

            return archivoBites;
        }
        public static string ObtenerMimeType(string pathArchivo)
        {
            string Extension = Path.GetExtension(pathArchivo).ToLower();

            //Diccionario de Extensiones a Tipo Mime

            Dictionary<string, string> mimeTypes = new Dictionary<string, string>()
            {
                 // Tipos MIME para imágenes
                { ".jpg", "image/jpg" },
                { ".jpeg", "image/jpeg" },
                { ".png", "image/png" },
                { ".gif", "image/gif" },
                { ".bmp", "image/bmp" },
                { ".tif", "image/tiff" },
                { ".tiff", "image/tiff" },

                // Tipos MIME para documentos
                { ".pdf", "application/pdf" },
                { ".doc", "application/msword" },
                { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { ".xls", "application/vnd.ms-excel" },
                { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                { ".ppt", "application/vnd.ms-powerpoint" },
                { ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
                { ".txt", "text/plain" },
                { ".csv", "text/csv" },
            };

            return mimeTypes.ContainsKey(Extension) ? mimeTypes[Extension] : "application/octet-stream";
        }
        internal bool RegistrarModificacion(AponusContext AponusDbContext, DTOMovimientosStock Mov)
        {
            try
            {
                AponusDbContext ??= AponusDBContext;
                DateTime FechaHora = UTL_Fechas.ObtenerFechaHora();

                var Movimiento = AponusDbContext.Stock_Movimientos.Where(x => x.IdMovimiento == Mov.IdMovimiento).FirstOrDefault();

                if (Movimiento != null)
                {
                    Movimiento.FechaHoraUltimaModificacion = FechaHora;
                    Movimiento.ModificadoUsuario = Mov.UsuarioModificacion;
                    AponusDbContext.Stock_Movimientos.Update(Movimiento);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return false;
            }

        }
        internal bool Eliminar(AponusContext AponusDBContext, int idMovimiento)
        {
            try
            {
                var Movimiento = AponusDBContext.Stock_Movimientos.FirstOrDefault(x => x.IdMovimiento == idMovimiento);

                if (Movimiento != null)
                {
                    Movimiento.IdEstadoMovimiento = 0;
                    AponusDBContext.Entry(Movimiento).CurrentValues.SetValues(Movimiento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal bool Actualizar(DTOMovimientosStock actualizacionMovimiento)
        {
            try
            {
                var Movimiento = AponusDBContext.Stock_Movimientos.FirstOrDefault(x => x.IdMovimiento == actualizacionMovimiento.IdMovimiento);

                if (Movimiento != null)
                {
                    Movimiento.FechaHoraUltimaModificacion = UTL_Fechas.ObtenerFechaHora();
                    Movimiento.ModificadoUsuario = actualizacionMovimiento.UsuarioModificacion ?? Movimiento.ModificadoUsuario;
                    Movimiento.IdProveedor = actualizacionMovimiento.IdProveedorDestino ?? Movimiento.IdProveedor;
                    Movimiento.Origen = actualizacionMovimiento.Origen ?? Movimiento.Origen;
                    Movimiento.Destino = actualizacionMovimiento.Destino ?? Movimiento.Destino;
                    Movimiento.Tipo = actualizacionMovimiento.Tipo ?? Movimiento.Tipo;
                    Movimiento.IdEstadoMovimiento = actualizacionMovimiento.IdEstado ?? Movimiento.IdEstadoMovimiento;

                    AponusDBContext.Entry(Movimiento).CurrentValues.SetValues(Movimiento);
                    AponusDBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}