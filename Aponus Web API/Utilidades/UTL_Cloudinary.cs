using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_Cloudinary
    {
        private readonly Cloudinary _cloudinary;
        private readonly HttpClient _httpClient;

        public UTL_Cloudinary()
        {
            var DatosCuenta = new Account("dxbgg3dtr", "748723842847532", "xT7aSgIFPip_8cu3mdb2jhj4LZk");

            _cloudinary = new Cloudinary(DatosCuenta);
            _httpClient = new HttpClient();
        }


        public List<(string HashArchivo, string Path)> SubirArchivosCloudinary(List<IFormFile> Archivos, string Proveedor)
        {
            List<(string HashArchivo, string Path)> DatosArchivosMovimiento = new List<(string HashArchivo, string Path)>();
            DateTime FechaHora = UTL_Fechas.ObtenerFechaHora();
            string Fecha = FechaHora.ToString("yyyyMMdd");
            string Hora = FechaHora.ToString("HHmmss");

            foreach (var Archivo in Archivos)
            {

                using (var stream = Archivo.OpenReadStream())
                {
                    var DatosSubida = new RawUploadParams()
                    {
                        File = new FileDescription(Archivo.FileName, stream),
                        PublicId = $"Aponus/Movimientos_Documentos/{Proveedor}/{Path.GetFileNameWithoutExtension(Archivo.FileName)}_{Fecha}_{Hora}"
                    };

                    var Resultado = _cloudinary.Upload(DatosSubida);

                    DatosArchivosMovimiento.Add((Archivo.FileName, Resultado.SecureUrl.ToString()));

                }
            }

            return DatosArchivosMovimiento;
        }

        public async Task<(string? url, string? error)> DescargarArchivo(string publicId)
        {
            try
            {
                var url = _cloudinary.Api.UrlImgUp.BuildUrl(publicId);
                //byte[] ArchivoBytes = await _httpClient.GetByteArrayAsync(url);
                return (url, null);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al descargar archivo de Cloudinary: {ex.InnerException?.Message ?? ex.Message}");
                return (null, $"Error al objener datos del archivo: {ex.InnerException?.Message ?? ex.Message}");

            }

        }

    }
}
