namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOInfoArchivosMovimientosStock
    {
        public int IdMovimiento { get; set; }
        public string NombreArchivo { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public string extension { get; set; }
        public byte[] DatosArchivo { get; set; }
    }
}
