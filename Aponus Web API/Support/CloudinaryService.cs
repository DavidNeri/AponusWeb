using Aponus_Web_API.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Aponus_Web_API.Support
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly HttpClient _httpClient;

        public CloudinaryService()
        {
            var DatosCuenta = new Account("dxbgg3dtr", "748723842847532", "xT7aSgIFPip_8cu3mdb2jhj4LZk");

            _cloudinary = new Cloudinary(DatosCuenta);
            _httpClient = new HttpClient();
        }
   

        public List<ArchivosMovimientosStock> SubirArchivosMovimiento(List<IFormFile> Archivos, string Proveedor)
        {
            List<ArchivosMovimientosStock> DatosArchivosMovimiento = new List<ArchivosMovimientosStock>();

            foreach (var Archivo in Archivos)
            {
                using(var stream = Archivo.OpenReadStream())
                {
                    var DatosSubida = new RawUploadParams()
                    {
                        File = new FileDescription(Archivo.FileName, stream),
                        PublicId = $"Aponus/Movimientos_Documentos/{Proveedor}"
                    };

                    var Resultado = _cloudinary.Upload(DatosSubida);

                    DatosArchivosMovimiento.Add(new ArchivosMovimientosStock()
                    {
                        HashArchivo = Archivo.FileName,
                        PathArchivo = Resultado.SecureUrl.ToString(),

                    });

                }
            }

            return DatosArchivosMovimiento;
        }

        public async Task<byte[]> DescargarArchivo(string publicId)
        {
            var url = _cloudinary.Api.UrlImgUp.BuildUrl(publicId);
            byte[] ArchivoBytes = await _httpClient.GetByteArrayAsync(url);

            return ArchivoBytes;
        
        }

    }
}
