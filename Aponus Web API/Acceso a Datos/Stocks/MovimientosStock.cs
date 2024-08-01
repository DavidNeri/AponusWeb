using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Aponus_Web_API.Support.Movimientos;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Net;

namespace Aponus_Web_API.Acceso_a_Datos.Stocks
{
    public class MovimientosStock
    {
        private readonly AponusContext AponusDBContext;
        public MovimientosStock() { AponusDBContext = new AponusContext(); }

        internal class Estados
        {
            internal static List<EstadosMovimientosStock> Listar(AponusContext AponusDbContext)
            {
               return AponusDbContext.EstadoMovimientosStock.Where(x=>x.IdEstadoPropio!=0 && !x.Descripcion.ToUpper().Contains("ELIMINADO")).ToList();  
                
            }

          
        }

        internal DTOMovimientosStock? ObtenerDatosMovimiento(int idMovimiento)
        {
            DTOMovimientosStock? Movimiento = AponusDBContext.Stock_Movimientos
                .Where(x => x.IdMovimiento == idMovimiento)
                .Select(x => new DTOMovimientosStock()
                {
                    IdMovimiento = x.IdMovimiento,
                    UsuarioCreacion = x.CreadoUsuario,
                    FechaHoraCreado = x.FechaHoraCreado,
                    FechaHoraUltimaModificacion = x.FechaHoraUltimaModificacion,
                    IdProveedorOrigen = x.IdProveedorOrigen,
                    IdProveedorDestino = x.IdProveedorDestino,
                    UsuarioModificacion = x.ModificadoUsuario,

                    DatosArchivos = AponusDBContext.ArchivosStock
                    .Where(x => x.IdMovimiento == x.IdMovimiento && x.IdEstado==1)
                    .Select(x => new DTODatosArchivosMovimientosStock()
                    {
                        IdMovimiento = x.IdMovimiento,
                        NombreArchivo = x.HashArchivo,
                        MimeType = x.MimeType,
                        Path = x.PathArchivo,
                        Extension = Path.GetExtension(x.PathArchivo),
                        DatosArchivo = DescargarArchivo(x.PathArchivo)
                        
                    }).ToList()
                })
                .FirstOrDefault();

            foreach (DTODatosArchivosMovimientosStock Archivo in Movimiento.DatosArchivos)
            {
                if (Archivo.MimeType==null || Archivo.Path!=null)
                {
                    Archivo.MimeType = ObtenerMimeType(Archivo.Path); 
                }
            }
           

            return Movimiento;
        }

        public class Archivos
        {
            private readonly AponusContext AponusDBContext;
            public Archivos() { AponusDBContext = new AponusContext(); }

            public bool Eliminar(AponusContext AponusDB,int IdMov, string Archivo)
            {
                try
                    {
                    var ArchivoExistente = AponusDB.ArchivosStock.Where(x => x.IdMovimiento == IdMov && x.HashArchivo.Contains(Archivo)).FirstOrDefault();

                    ArchivoExistente.IdEstado = 0;
                    AponusDB.ArchivosStock.Update(ArchivoExistente);
                    
                    return true;
                }
                catch (DbUpdateException ex)
                {
                        return false;
                }
                
                                

            }
        }

        public IActionResult Listar(FiltrosMovimientos? Filtros = null)
        {
           
            IQueryable<DTOMovimientosStock> ListadoMovimientos = AponusDBContext.Stock_Movimientos
                .Join(
                    AponusDBContext.Entidades,
                    movimientos => movimientos.IdProveedorOrigen,
                    proveedorOrigen => proveedorOrigen.IdEntidad,
                    (movimiento, proveedorOrigen) => new { Movimiento = movimiento, ProveedorOrigen = proveedorOrigen }
                )
                .Join(
                    AponusDBContext.Entidades,
                    movimiento_ProveedorOrigen => movimiento_ProveedorOrigen.Movimiento.IdProveedorDestino,
                    proveedorDestino => proveedorDestino.IdEntidad,
                    (movimiento_ProveedorOrigen, proveedorDestino) => new { Movimiento_ProveedorOrigen = movimiento_ProveedorOrigen, ProveedorDestino = proveedorDestino }
                )
                .Join(
                    AponusDBContext.SuministrosMovimientoStock,
                    Movimientos_Provedores => Movimientos_Provedores.Movimiento_ProveedorOrigen.Movimiento.IdMovimiento,
                    SuministrosMovimientos => SuministrosMovimientos.IdMovimiento,
                    (movimientos_Proveedores, SuministrosMovimientos) => new { movimientos_proveedores = movimientos_Proveedores, suministrosMovimientos = SuministrosMovimientos }


                )
                .Join(
                    AponusDBContext.ComponentesDetalles,
                    Movimientos_Proveedores_Suministros=>Movimientos_Proveedores_Suministros.suministrosMovimientos.IdSuministro,
                    SuministrosDetalle=> SuministrosDetalle.IdInsumo,
                    (movimientos_Proveedores_Suministros, suministrosDetalle) => new { Movimientos_Proveedores_Suministros = movimientos_Proveedores_Suministros, SuministrosDetalle = suministrosDetalle })

                .Join(
                    AponusDBContext.EstadoMovimientosStock,
                    Mov_Prov_Sum_Det=> Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdEstado,
                    Estados=>Estados.IdEstado,
                    (Mov_Prov_Sum_Det,Estados)=> new { Mov_Prov_Sum_Det, Estados })

                .Where(x=>x.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdEstado!=0)
                .Select(result => new DTOMovimientosStock()
                {
                    IdMovimiento = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdMovimiento,
                    FechaHoraCreado = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.FechaHoraCreado,
                    UsuarioCreacion = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.CreadoUsuario,
                    Origen = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.Origen,
                    Destino= result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.Destino,                    
                    Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.Estados.Descripcion.ToLower()),

                    Suministros = AponusDBContext.SuministrosMovimientoStock
                    .Where(s => s.IdMovimiento == result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdMovimiento && Convert.ToInt32(s.IdEstado)==Convert.ToInt32("0x01",16))
                    .Select(s => new DTOSuministrosMovimientosStock()
                    {
                        IdMovimiento = s.IdMovimiento,
                        Cantidad = !string.IsNullOrEmpty(s.Cantidad.ToString()) ?
                            s.Cantidad.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento) : 
                            0.00.ToString() + (result.Mov_Prov_Sum_Det.SuministrosDetalle.IdFraccionamiento ?? result.Mov_Prov_Sum_Det.SuministrosDetalle.IdAlmacenamiento),

                        IdSuministro = s.IdSuministro,
                        ValorAnteriorDestino = !string.IsNullOrEmpty(s.ValorAnteriorDestino.ToString()) ? s.ValorAnteriorDestino.ToString() : 0.00.ToString(),
                        ValorAnteriorOrigen = !string.IsNullOrEmpty(s.ValorAnteriorOrigen.ToString()) ? s.ValorAnteriorOrigen.ToString() : 0.00.ToString(),
                        ValorNuevoDestino = !string.IsNullOrEmpty(s.ValorNuevoDestino.ToString()) ? s.ValorNuevoDestino.ToString() : 0.00.ToString(),
                        ValorNuevoOrigen = !string.IsNullOrEmpty(s.ValorNuevoOrigen.ToString()) ? s.ValorNuevoOrigen.ToString() : 0.00.ToString(),

                    })
                    .ToList(),

                    ProveedorOrigen = new DTOEntidades()
                    {
                        IdEntidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.IdEntidad,
                        Nombre = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Nombre,
                        Apellido= result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Apellido,
                        NombreClave = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.NombreClave,
                        Pais = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Pais,
                        Localidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Localidad,
                        Calle = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Calle,
                        Altura = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Altura,
                        CodigoPostal = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.CodigoPostal,
                        Telefono1 = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Telefono1,
                        Telefono2 = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Telefono2,
                        Telefono3 = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Telefono3,
                        Email = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Email,
                        IdFiscal = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.IdFiscal,
                        FechaRegistro = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.FechaRegistro,

                    },

                    ProveedorDestino = new DTOEntidades()
                    {
                        IdEntidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.IdEntidad,
                        Nombre = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Nombre,
                        Apellido = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Apellido,
                        NombreClave = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.NombreClave,
                        Pais = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Pais,
                        Localidad = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Localidad,
                        Calle = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Calle,
                        Altura = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Altura,
                        CodigoPostal = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.CodigoPostal,
                        Telefono1 = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Telefono1,
                        Telefono2 = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Telefono2,
                        Telefono3 = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Telefono3,
                        Email = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.Email,
                        IdFiscal = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.IdFiscal,
                        FechaRegistro = result.Mov_Prov_Sum_Det.Movimientos_Proveedores_Suministros.movimientos_proveedores.ProveedorDestino.FechaRegistro,

                    }

                });


            if (Filtros != null)
            {
                var CondicionWhere = new FiltrosMovimientos().ConstruirCondicionWhere(Filtros);
                var Listado = ListadoMovimientos.Where(CondicionWhere);
                return new JsonResult(Listado);
            }


            List<string>SuministrosId=ListadoMovimientos
                .SelectMany(x=>x.Suministros.Select(x=>x.IdSuministro))
                .ToList();

            List<(string IdSuministro,
               string NombreFormateado,
               string? Unidad)> SuministrosFormateados = new ObtenerInsumos().ObtenerDetalleSuministro(SuministrosId);


            foreach (var movimiento in ListadoMovimientos)
            {
                foreach (var suministro in movimiento.Suministros)
                {
                        (string IdSuministro,
                         string NombreFormateado,
                         string? Unidad)
                        SumFormat = SuministrosFormateados.FirstOrDefault(x=>x.IdSuministro==suministro.IdSuministro);

                    suministro.NombreSuministro = SumFormat.NombreFormateado;
                    suministro.Cantidad = suministro.Cantidad + " " + SumFormat.Unidad;
                    suministro.ValorNuevoDestino = suministro.ValorNuevoDestino + " " + SumFormat.Unidad;
                    suministro.ValorNuevoOrigen = suministro.ValorNuevoOrigen + " " + SumFormat.Unidad;
                    suministro.ValorAnteriorOrigen = suministro.ValorAnteriorOrigen + "" + SumFormat.Unidad;
                    suministro.ValorAnteriorDestino = suministro.ValorAnteriorDestino + " " + SumFormat.Unidad;
                }
            }

          

            
            var MovimientosIds = ListadoMovimientos.Select(m=>m.IdMovimiento).Distinct().ToList();
           
            List<DTODatosArchivosMovimientosStock> InfoArchivosMovimientos = AponusDBContext.ArchivosStock
                .Where(Id=>MovimientosIds.Contains(Id.IdMovimiento))
                .Select(Reg=> new DTODatosArchivosMovimientosStock()
                {
                    IdMovimiento= Reg.IdMovimiento,
                    NombreArchivo = Reg.HashArchivo,
                    Path = Reg.PathArchivo,
                    Extension = Path.GetExtension(Reg.PathArchivo),
                    MimeType = ObtenerMimeType(Reg.PathArchivo),
                    DatosArchivo = DescargarArchivo(Reg.PathArchivo)
                    
                })
                .ToList();

            foreach (DTOMovimientosStock Movimiento in ListadoMovimientos)
            {
                Movimiento.DatosArchivos=InfoArchivosMovimientos
                    .Where(x=>x.IdMovimiento==Movimiento.IdMovimiento)
                    .ToList();
                
            }


            return new JsonResult(ListadoMovimientos);

        }

        private static byte[] DescargarArchivo(string url)
        {
            WebClient webClient = new WebClient();
            byte[] archivoBites = webClient.DownloadData(url);            

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

        internal bool RegistrarModificacion(AponusContext AponusDbContext,DTOMovimientosStock Mov)
        {
            try
            {
                if (AponusDbContext == null)
                {
                    AponusDbContext = new AponusContext();
                }

               
                DateTime FechaHora = Fechas.ObtenerFechaHora();
                var Movimiento = AponusDBContext.Stock_Movimientos.Where(x=>x.IdMovimiento==Mov.IdMovimiento).FirstOrDefault();
                Movimiento.FechaHoraUltimaModificacion=FechaHora;
                Movimiento.ModificadoUsuario=Mov.UsuarioModificacion;                             
                  
                
                AponusDbContext.Stock_Movimientos.Update(Movimiento);


                return true;
                
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return false;
            }
            
        }

        internal static bool Eliminar(AponusContext AponusDBContext, int idMovimiento)
        {
            try
            {
                var Movimiento = AponusDBContext.Stock_Movimientos.FirstOrDefault(x => x.IdMovimiento == idMovimiento);
                if (Movimiento!=null)
                {
                    Movimiento.IdEstado = 0;
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
                    Movimiento.FechaHoraUltimaModificacion = Fechas.ObtenerFechaHora();
                    Movimiento.ModificadoUsuario = actualizacionMovimiento.UsuarioModificacion ?? Movimiento.ModificadoUsuario;
                    Movimiento.IdProveedorOrigen = actualizacionMovimiento.IdProveedorOrigen ?? Movimiento.IdProveedorOrigen;
                    Movimiento.IdProveedorDestino = actualizacionMovimiento.IdProveedorDestino ?? Movimiento.IdProveedorDestino;
                    Movimiento.Origen = actualizacionMovimiento.Origen ?? Movimiento.Origen;
                    Movimiento.Destino = actualizacionMovimiento.Destino ?? Movimiento.Destino;
                    Movimiento.Tipo = actualizacionMovimiento.Tipo ?? Movimiento.Tipo;
                    Movimiento.IdEstado = actualizacionMovimiento.IdEstado ?? Movimiento.IdEstado;

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
