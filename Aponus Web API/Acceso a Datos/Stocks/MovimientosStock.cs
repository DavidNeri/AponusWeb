using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Net;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Acceso_a_Datos.Stocks
{
    public class MovimientosStock
    {
        private readonly AponusContext AponusDBContext;
        public MovimientosStock() { AponusDBContext = new AponusContext(); }
        public IActionResult Listar()
        {
            List<DTOMovimientosStock> ListadoMovimientos = AponusDBContext.Stock_Movimientos
                .Join(
                    AponusDBContext.Proveedores,
                    movimientos => movimientos.IdProveedorOrigen,
                    proveedorOrigen => proveedorOrigen.IdProveedor,
                    (movimiento, proveedorOrigen) => new { Movimiento = movimiento, ProveedorOrigen = proveedorOrigen }
                )
                .Join(
                    AponusDBContext.Proveedores,
                    movimiento_ProveedorOrigen => movimiento_ProveedorOrigen.Movimiento.IdProveedorDestino,
                    proveedorDestino => proveedorDestino.IdProveedor,
                    (movimiento_ProveedorOrigen, proveedorDestino) => new { Movimiento_ProveedorOrigen = movimiento_ProveedorOrigen, ProveedorDestino = proveedorDestino }
                )
                .Join(
                    AponusDBContext.SuministrosMovimientoStock,
                    Movimientos_Provedores => Movimientos_Provedores.Movimiento_ProveedorOrigen.Movimiento.IdMovimiento,
                    SuministrosMovimientos => SuministrosMovimientos.IdMovimiento,
                    (movimientos_Proveedores, SuministrosMovimientos) => new { movimientos_proveedores = movimientos_Proveedores, suministrosMovimientos = SuministrosMovimientos }


                )


                .Select(result => new DTOMovimientosStock()
                {
                    IdMovimiento = result.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdMovimiento,                    
                    FechaHora = result.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.FechaHora,
                    Usuario = result.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdUsuario,

                    Suministros = AponusDBContext.SuministrosMovimientoStock
                    .Where(s => s.IdMovimiento == result.movimientos_proveedores.Movimiento_ProveedorOrigen.Movimiento.IdMovimiento)
                    .Select(s => new DTOSuministrosMovimientosStock()
                    {
                        IdMovimiento= s.IdMovimiento,
                        CampoStockDestino= s.CampoStockDestino,
                        CampoStockOrigen= s.CampoStockOrigen,
                        Cantidad= s.Cantidad,
                        IdSuministro= s.IdSuministro,
                        ValorAnteriorDestino = s.ValorAnteriorDestino,
                        ValorAnteriorOrigen = s.ValorAnteriorOrigen,
                         ValorNuevoDestino = s.ValorNuevoDestino,
                         ValorNuevoOrigen = s.ValorNuevoOrigen


                    })
                    .ToList(),

                    ProveedorOrigen = new DTOProveedores()
                    {
                        IdProveedor = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.IdProveedor,
                        NombreProveedor = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.NombreProveedor,
                        Pais = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Pais,
                        Localidad = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Localidad,
                        Calle = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Calle,
                        Altura = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Altura,
                        CodigoPostal = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.CodigoPostal,
                        Telefono1 = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Telefono1,
                        Telefono2 = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Telefono2,
                        Telefono3 = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Telefono3,
                        Email = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.Email,
                        IdFiscal = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.IdFiscal,
                        FechaRegistro = result.movimientos_proveedores.Movimiento_ProveedorOrigen.ProveedorOrigen.FechaRegistro,

                    },

                    ProveedorDestino = new DTOProveedores()
                    {
                        IdProveedor = result.movimientos_proveedores.ProveedorDestino.IdProveedor,
                        NombreProveedor = result.movimientos_proveedores.ProveedorDestino.NombreProveedor,
                        Pais = result.movimientos_proveedores.ProveedorDestino.Pais,
                        Localidad = result.movimientos_proveedores.ProveedorDestino.Localidad,
                        Calle = result.movimientos_proveedores.ProveedorDestino.Calle,
                        Altura = result.movimientos_proveedores.ProveedorDestino.Altura,
                        CodigoPostal = result.movimientos_proveedores.ProveedorDestino.CodigoPostal,
                        Telefono1 = result.movimientos_proveedores.ProveedorDestino.Telefono1,
                        Telefono2 = result.movimientos_proveedores.ProveedorDestino.Telefono2,
                        Telefono3 = result.movimientos_proveedores.ProveedorDestino.Telefono3,
                        Email = result.movimientos_proveedores.ProveedorDestino.Email,
                        IdFiscal = result.movimientos_proveedores.ProveedorDestino.IdFiscal,
                        FechaRegistro = result.movimientos_proveedores.ProveedorDestino.FechaRegistro,

                    }

                })               
                .ToList();

            List<string>SuministrosId=ListadoMovimientos
                .SelectMany(x=>x.Suministros.Select(x=>x.IdSuministro))
                .ToList();

            List<(string IdSuministro,
               string NombreFormateado,
               string? Unidad)> SuministrosFormateados = new ObtenerInsumos().ObtenerDetalleSuministro(SuministrosId);


           /* ListadoMovimientos=ListadoMovimientos
                .Join(
                    SuministrosFormateados,
                    ListMov=>ListMov.Suministros.Select(x=>x.IdSuministro),
                    SumForm=>SumForm.IdSuministro,
                    (ListMov, SumForm)=>
                    {
                        ListMov.Suministros.Select(x=>x.IdSuministro) = SumForm.NombreFormateado;
                        ListMov.Valor = ListMov.Valor + " " + SumForm.Unidad; 
                        return ListMov;
                    })
                .ToList();
           */

            var MovimientosIds = ListadoMovimientos.Select(m=>m.IdMovimiento).Distinct().ToList();
           
            List<DTOInfoArchivosMovimientosStock> InfoArchivosMovimientos = AponusDBContext.ArchivosStock
                .Where(Id=>MovimientosIds.Contains(Id.IdMovimiento))
                .Select(Reg=> new DTOInfoArchivosMovimientosStock()
                {
                    IdMovimiento= Reg.IdMovimiento,
                    NombreArchivo = Reg.HashArchivo,
                    Path = Reg.PathArchivo,
                    extension = Path.GetExtension(Reg.PathArchivo),
                    MimeType = ObtenerMimeType(Reg.PathArchivo),
                    DatosArchivo = DescargarArchivo(Reg.PathArchivo)
                    
                })
                .ToList();

            foreach (DTOMovimientosStock Movimiento in ListadoMovimientos)
            {
                Movimiento.Archivos=InfoArchivosMovimientos
                    .Where(x=>x.IdMovimiento==Movimiento.IdMovimiento)
                    .ToList();
                
            }

            
            //Prueba para copiar los archivos
            foreach (var archivo in InfoArchivosMovimientos)
            {
                File.WriteAllBytes($"C:\\Aponus\\"+archivo.NombreArchivo+""+Path.GetExtension(archivo.Path), archivo.DatosArchivo);
            }
            //Prueba para copiar los archivos
           


            return new JsonResult(ListadoMovimientos);

        }

        private static byte[] DescargarArchivo(string url)
        {
            WebClient webClient = new WebClient();
            byte[] archivoBites = webClient.DownloadData(url);            

            return archivoBites;
        }

        private static string ObtenerMimeType(string pathArchivo)
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
    }
}
